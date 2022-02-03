package main

import (
    "fmt"
    "net/http"
	"io/ioutil"
	"io"
	"os"
    "mime/multipart"
	"bytes"
	"encoding/json"
	"path/filepath"
	"strconv"
	"strings"
)

type attachmentResponse struct {
	
	ContentMD5 string
	Metadata []string
	Creator string
	Success bool
	Name string
	Guid string
	ContentEncoding string
	ContentLanguage string
	ETag string
	ContentLength int
	ServerTime int
	LastModified int
	ExpiredTimestamp int
	ContentType string
	
}


type AttachmentList struct {
	Entities []struct {
		EntityType string `json:"entity_type"`
		Properties struct {
			Lastupdatetime      int64  `json:"LastUpdateTime"`
			Incidentattachments string `json:"IncidentAttachments"`
			Requestattachments string `json:"RequestAttachments"`
			ID                  string `json:"Id"`
		} `json:"properties"`
		RelatedProperties struct {
		} `json:"related_properties"`
	} `json:"entities"`
	Meta struct {
		CompletionStatus     string        `json:"completion_status"`
		TotalCount           int           `json:"total_count"`
		Errordetailslist     []interface{} `json:"errorDetailsList"`
		Errordetailsmetalist []interface{} `json:"errorDetailsMetaList"`
		QueryTime            int64         `json:"query_time"`
	} `json:"meta"`
}

var myResponse attachmentResponse
var myAttachments AttachmentList

var DEBUG bool

func init() {
	DEBUG = false
}

func mustOpen(f string) *os.File {
    r, err := os.Open(f)
    if err != nil {
        panic(err)
    }
    return r
}

func get_auth_token(user, pass, site, tenantID string) string {

	url := site+"/auth/authentication-endpoint/authenticate/login?TENANTID="+tenantID
    if DEBUG {fmt.Printf("token URL: %s\n\n",url)}
	
    var jsonStr = []byte(`{"login": "`+user+`","password": "`+pass+`"}`)
	if DEBUG {fmt.Printf("token string: %s\n\n",jsonStr)}
	
    req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
    req.Header.Set("Content-Type", "application/json")

    client := &http.Client{}
    resp, err := client.Do(req)
    if err != nil {
        panic(err)
    }
    defer resp.Body.Close()


    body, _ := ioutil.ReadAll(resp.Body)
	token := string(body)
	
    if DEBUG {
		fmt.Println("response Status:", resp.Status)
		fmt.Printf("response Headers: %s\n\n", resp.Header)
		fmt.Printf("response Body:%s\n\n", token)
	}
	return token
}

func get_attachment_list(site, ticket, tenantID, token, ticketType string) string {

	url := site+"/rest/"+tenantID+"/ems/"+ticketType+"/"+ticket+"/?layout="+ticketType+"Attachments"
	
	if DEBUG {fmt.Printf("Attachment List URL: %s\n\n",url)}
	
	attach_list_req, err := http.NewRequest("GET", url, nil)
	if (err != nil) {
		panic(err)
	}
	
    attach_list_req.Header.Set("Cookie", "SMAX_AUTH_TOKEN="+token+";TENANTID="+tenantID)
    
    client := &http.Client{}
    attach_list_resp, attach_list_err := client.Do(attach_list_req)
    if attach_list_err != nil {
        panic(attach_list_err)
    }
    defer attach_list_resp.Body.Close()
	
    body, _ := ioutil.ReadAll(attach_list_resp.Body)
	if DEBUG {fmt.Printf("Attachment list response Body:%s\n\n", body)}
	
	err = json.Unmarshal(body, &myAttachments)
	if err != nil {
        panic(err)
    }
	
	if DEBUG {fmt.Printf( "Attachment List Data: %+v\n\n", myAttachments)}
	
	previousAttachments := ""
	
	if (ticketType == "Request") {
		if DEBUG {fmt.Printf("previous attachments: %s\n\n", myAttachments.Entities[0].Properties.Requestattachments)}
		tempList := strings.Replace(myAttachments.Entities[0].Properties.Requestattachments, `{"complexTypeProperties":[`,"",-1)
		previousAttachments = strings.Replace(tempList, `]}`,"",-1)
		if DEBUG {fmt.Printf("UPDATED previous attachments: %s\n\n", previousAttachments)}
	} else {
		if DEBUG {fmt.Printf("previous attachments: %s\n\n", myAttachments.Entities[0].Properties.Incidentattachments)}
		tempList := strings.Replace(myAttachments.Entities[0].Properties.Incidentattachments, `{"complexTypeProperties":[`,"",-1)
		previousAttachments = strings.Replace(tempList, `]}`,"",-1)
		if DEBUG {fmt.Printf("UPDATED previous attachments: %s\n\n", previousAttachments)}
	}
	
	if (len(previousAttachments) > 1) {
		type previousAttachmentData struct {
			Complextypeproperties []struct {
				Properties struct {
					ID            string `json:"id"`
					FileName      string `json:"file_name"`
					FileExtension string `json:"file_extension"`
					Size          string `json:"size"`
					MimeType      string `json:"mime_type"`
					Creator       string `json:"Creator"`
				} `json:"properties"`
			} `json:"complexTypeProperties"`
		}

		var myPrevAttach previousAttachmentData
		
		err = json.Unmarshal([]byte(previousAttachments), &myPrevAttach)
		if err != nil {
			panic(err)
		}
		
		if DEBUG {
			fmt.Printf("Attachment List Struct: %+v\n\n", myPrevAttach)
			fmt.Printf("Properties length: %s, data: %+v\n\n", len(myPrevAttach.Complextypeproperties), myPrevAttach.Complextypeproperties[0].Properties)
		}
	
		for i := 0; i < len(myPrevAttach.Complextypeproperties); i++ {
			out, err := json.Marshal(myPrevAttach.Complextypeproperties[i].Properties)
			if err != nil {
				panic (err)
			}
			if (i == 0) {
				previousAttachments = `{"properties":`+string(out)+`}`
			} else {
				previousAttachments += `,{"properties":`+string(out)+`}`
			}
		}
	}
	
	if (len(previousAttachments) > 1) {
		tempList := ","+previousAttachments
		previousAttachments = strings.Replace(tempList, `"`,`\"`,-1)
	}
	return previousAttachments
}

func upload_file(attachfile, token, site, tenantID string) bool {

	values := map[string]io.Reader{
        "files[]":  mustOpen(attachfile), // lets assume its this file
    }
	var err error
	
	var b bytes.Buffer
    w := multipart.NewWriter(&b)
    for key, r := range values {
        var fw io.Writer
        if x, ok := r.(io.Closer); ok {
            defer x.Close()
        }
        // Add an image file
        if x, ok := r.(*os.File); ok {
            if fw, err = w.CreateFormFile(key, x.Name()); err != nil {
                return false
            }
        } else {
            // Add other fields
            if fw, err = w.CreateFormField(key); err != nil {
                return false
            }
        }
        if _, err = io.Copy(fw, r); err != nil {
            fmt.Printf("error %s", err)
        }

    }
    // Don't forget to close the multipart writer.
    // If you don't close it, your request will be missing the terminating boundary.
    w.Close()
	
	// end of file processing
	
	
	url := site+"/rest/"+tenantID+"/ces/attachment/"
	if DEBUG {fmt.Printf("Attachment URL: %s\n",url)}
	
	attachment_req, err := http.NewRequest("POST", url, &b)
    attachment_req.Header.Set("Cookie", "SMAX_AUTH_TOKEN="+token+";TENANTID="+tenantID)
    attachment_req.Header.Set("Content-Type", w.FormDataContentType())
	
    client := &http.Client{}
    attachment_resp, attach_err := client.Do(attachment_req)
    if attach_err != nil {
        panic(attach_err)
    }
    defer attachment_resp.Body.Close()
	
    body, _ := ioutil.ReadAll(attachment_resp.Body)
	
    err = json.Unmarshal(body, &myResponse)
	if err != nil {
        panic(err)
    }
	
	if DEBUG {
		fmt.Println("attachment response Status:", attachment_resp.Status)
		fmt.Printf("attachment response Headers: %s\n\n", attachment_resp.Header)
		fmt.Printf("attachment response Body:%s\n\n", body)
		fmt.Printf( "Attachment Data: %+v", myResponse)
	}
	
	return myResponse.Success
}

func get_mimetype(ext string) string {

	switch ext {
		case "3dm": return "x-world/x-3dmf"
		case "3dmf": return "x-world/x-3dmf"
		case "a": return "application/octet-stream"
		case "aab": return "application/x-authorware-bin"
		case "aam": return "application/x-authorware-map"
		case "aas": return "application/x-authorware-seg"
		case "abc": return "text/vnd.abc"
		case "acgi": return "text/html"
		case "afl": return "video/animaflex"
		case "ai": return "application/postscript"
		case "aif": return "audio/aiff"
		case "aifc": return "audio/aiff"
		case "aiff": return "audio/aiff"
		case "aim": return "application/x-aim"
		case "aip": return "text/x-audiosoft-intra"
		case "ani": return "application/x-navi-animation"
		case "aos": return "application/x-nokia-9000-communicator-add-on-software"
		case "aps": return "application/mime"
		case "arc": return "application/octet-stream"
		case "arj": return "application/arj"
		case "art": return "image/x-jg"
		case "asf": return "video/x-ms-asf"
		case "asm": return "text/x-asm"
		case "asp": return "text/asp"
		case "asx": return "application/x-mplayer2"
		case "au": return "audio/basic"
		case "avi": return "application/x-troff-msvideo"
		case "avs": return "video/avs-video"
		case "bcpio": return "application/x-bcpio"
		case "bin": return "application/mac-binary"
		case "bm": return "image/bmp"
		case "bmp": return "image/bmp"
		case "boo": return "application/book"
		case "book": return "application/book"
		case "boz": return "application/x-bzip2"
		case "bsh": return "application/x-bsh"
		case "bz": return "application/x-bzip"
		case "bz2": return "application/x-bzip2"
		case "c": return "text/plain"
		case "c++": return "text/plain"
		case "cat": return "application/vnd.ms-pki.seccat"
		case "cc": return "text/plain"
		case "ccad": return "application/clariscad"
		case "cco": return "application/x-cocoa"
		case "cdf": return "application/cdf"
		case "cer": return "application/pkix-cert"
		case "cha": return "application/x-chat"
		case "chat": return "application/x-chat"
		case "class": return "application/java"
		case "com": return "application/octet-stream"
		case "conf": return "text/plain"
		case "cpio": return "application/x-cpio"
		case "cpp": return "text/x-c"
		case "cpt": return "application/mac-compactpro"
		case "crl": return "application/pkcs-crl"
		case "crt": return "application/pkix-cert"
		case "csh": return "application/x-csh"
		case "css": return "application/x-pointplus"
		case "cxx": return "text/plain"
		case "dcr": return "application/x-director"
		case "deepv": return "application/x-deepv"
		case "def": return "text/plain"
		case "der": return "application/x-x509-ca-cert"
		case "dif": return "video/x-dv"
		case "dir": return "application/x-director"
		case "dl": return "video/dl"
		case "doc": return "application/msword"
		case "dot": return "application/msword"
		case "dp": return "application/commonground"
		case "drw": return "application/drafting"
		case "dump": return "application/octet-stream"
		case "dv": return "video/x-dv"
		case "dvi": return "application/x-dvi"
		case "dwf": return "drawing/x-dwf (old)"
		case "dwg": return "application/acad"
		case "dxf": return "application/dxf"
		case "dxr": return "application/x-director"
		case "el": return "text/x-script.elisp"
		case "elc": return "application/x-bytecode.elisp (compiled elisp)"
		case "env": return "application/x-envoy"
		case "eps": return "application/postscript"
		case "es": return "application/x-esrehber"
		case "etx": return "text/x-setext"
		case "evy": return "application/envoy"
		case "exe": return "application/octet-stream"
		case "f": return "text/plain"
		case "f77": return "text/x-fortran"
		case "f90": return "text/plain"
		case "fdf": return "application/vnd.fdf"
		case "fif": return "application/fractals"
		case "fli": return "video/fli"
		case "flo": return "image/florian"
		case "flx": return "text/vnd.fmi.flexstor"
		case "fmf": return "video/x-atomic3d-feature"
		case "for": return "text/plain"
		case "fpx": return "image/vnd.fpx"
		case "frl": return "application/freeloader"
		case "funk": return "audio/make"
		case "g": return "text/plain"
		case "g3": return "image/g3fax"
		case "gif": return "image/gif"
		case "gl": return "video/gl"
		case "gsd": return "audio/x-gsm"
		case "gsm": return "audio/x-gsm"
		case "gsp": return "application/x-gsp"
		case "gss": return "application/x-gss"
		case "gtar": return "application/x-gtar"
		case "gz": return "application/x-compressed"
		case "gzip": return "application/x-gzip"
		case "h": return "text/plain"
		case "hdf": return "application/x-hdf"
		case "help": return "application/x-helpfile"
		case "hgl": return "application/vnd.hp-hpgl"
		case "hh": return "text/plain"
		case "hlb": return "text/x-script"
		case "hlp": return "application/hlp"
		case "hpg": return "application/vnd.hp-hpgl"
		case "hpgl": return "application/vnd.hp-hpgl"
		case "hqx": return "application/binhex"
		case "hta": return "application/hta"
		case "htc": return "text/x-component"
		case "htm": return "text/html"
		case "html": return "text/html"
		case "htmls": return "text/html"
		case "htt": return "text/webviewhtml"
		case "htx": return "text/html"
		case "ice": return "x-conference/x-cooltalk"
		case "ico": return "image/x-icon"
		case "idc": return "text/plain"
		case "ief": return "image/ief"
		case "iefs": return "image/ief"
		case "iges": return "application/iges"
		case "igs": return "application/iges"
		case "ima": return "application/x-ima"
		case "imap": return "application/x-httpd-imap"
		case "inf": return "application/inf"
		case "ins": return "application/x-internett-signup"
		case "ip": return "application/x-ip2"
		case "isu": return "video/x-isvideo"
		case "it": return "audio/it"
		case "iv": return "application/x-inventor"
		case "ivr": return "i-world/i-vrml"
		case "ivy": return "application/x-livescreen"
		case "jam": return "audio/x-jam"
		case "jav": return "text/plain"
		case "java": return "text/plain"
		case "jcm": return "application/x-java-commerce"
		case "jfif": return "image/jpeg"
		case "jfif-tbnl": return "image/jpeg"
		case "jpe": return "image/jpeg"
		case "jpeg": return "image/jpeg"
		case "jpg": return "image/jpeg"
		case "jps": return "image/x-jps"
		case "js": return "application/x-javascript"
		case "jut": return "image/jutvision"
		case "kar": return "audio/midi"
		case "ksh": return "application/x-ksh"
		case "la": return "audio/nspaudio"
		case "lam": return "audio/x-liveaudio"
		case "latex": return "application/x-latex"
		case "lha": return "application/lha"
		case "lhx": return "application/octet-stream"
		case "list": return "text/plain"
		case "lma": return "audio/nspaudio"
		case "log": return "text/plain"
		case "lsp": return "application/x-lisp"
		case "lst": return "text/plain"
		case "lsx": return "text/x-la-asf"
		case "ltx": return "application/x-latex"
		case "lzh": return "application/octet-stream"
		case "lzx": return "application/lzx"
		case "m": return "text/plain"
		case "m1v": return "video/mpeg"
		case "m2a": return "audio/mpeg"
		case "m2v": return "video/mpeg"
		case "m3u": return "audio/x-mpequrl"
		case "man": return "application/x-troff-man"
		case "map": return "application/x-navimap"
		case "mar": return "text/plain"
		case "mbd": return "application/mbedlet"
		case "mc$": return "application/x-magic-cap-package-1.0"
		case "mcd": return "application/mcad"
		case "mcf": return "image/vasa"
		case "mcp": return "application/netmc"
		case "me": return "application/x-troff-me"
		case "mht": return "message/rfc822"
		case "mhtml": return "message/rfc822"
		case "mid": return "application/x-midi"
		case "midi": return "application/x-midi"
		case "mif": return "application/x-frame"
		case "mime": return "message/rfc822"
		case "mjf": return "audio/x-vnd.audioexplosion.mjuicemediafile"
		case "mjpg": return "video/x-motion-jpeg"
		case "mm": return "application/base64"
		case "mme": return "application/base64"
		case "mod": return "audio/mod"
		case "moov": return "video/quicktime"
		case "mov": return "video/quicktime"
		case "movie": return "video/x-sgi-movie"
		case "mp2": return "audio/mpeg"
		case "mp3": return "audio/mpeg3"
		case "mpa": return "audio/mpeg"
		case "mpc": return "application/x-project"
		case "mpe": return "video/mpeg"
		case "mpeg": return "video/mpeg"
		case "mpg": return "audio/mpeg"
		case "mpga": return "audio/mpeg"
		case "mpp": return "application/vnd.ms-project"
		case "mpt": return "application/x-project"
		case "mpv": return "application/x-project"
		case "mpx": return "application/x-project"
		case "mrc": return "application/marc"
		case "ms": return "application/x-troff-ms"
		case "mv": return "video/x-sgi-movie"
		case "my": return "audio/make"
		case "mzz": return "application/x-vnd.audioexplosion.mzz"
		case "nap": return "image/naplps"
		case "naplps": return "image/naplps"
		case "nc": return "application/x-netcdf"
		case "ncm": return "application/vnd.nokia.configuration-message"
		case "nif": return "image/x-niff"
		case "niff": return "image/x-niff"
		case "nix": return "application/x-mix-transfer"
		case "nsc": return "application/x-conference"
		case "nvd": return "application/x-navidoc"
		case "o": return "application/octet-stream"
		case "oda": return "application/oda"
		case "omc": return "application/x-omc"
		case "omcd": return "application/x-omcdatamaker"
		case "omcr": return "application/x-omcregerator"
		case "p": return "text/x-pascal"
		case "p10": return "application/pkcs10"
		case "p12": return "application/pkcs-12"
		case "p7a": return "application/x-pkcs7-signature"
		case "p7c": return "application/pkcs7-mime"
		case "p7m": return "application/pkcs7-mime"
		case "p7r": return "application/x-pkcs7-certreqresp"
		case "p7s": return "application/pkcs7-signature"
		case "part": return "application/pro_eng"
		case "pas": return "text/pascal"
		case "pbm": return "image/x-portable-bitmap"
		case "pcl": return "application/vnd.hp-pcl"
		case "pct": return "image/x-pict"
		case "pcx": return "image/x-pcx"
		case "pdb": return "chemical/x-pdb"
		case "pdf": return "application/pdf"
		case "pfunk": return "audio/make"
		case "pgm": return "image/x-portable-graymap"
		case "pic": return "image/pict"
		case "pict": return "image/pict"
		case "pkg": return "application/x-newton-compatible-pkg"
		case "pko": return "application/vnd.ms-pki.pko"
		case "pl": return "text/plain"
		case "plx": return "application/x-pixclscript"
		case "pm": return "image/x-xpixmap"
		case "pm4": return "application/x-pagemaker"
		case "pm5": return "application/x-pagemaker"
		case "png": return "image/png"
		case "pnm": return "application/x-portable-anymap"
		case "pot": return "application/mspowerpoint"
		case "pov": return "model/x-pov"
		case "ppa": return "application/vnd.ms-powerpoint"
		case "ppm": return "image/x-portable-pixmap"
		case "pps": return "application/mspowerpoint"
		case "ppt": return "application/mspowerpoint"
		case "ppz": return "application/mspowerpoint"
		case "pre": return "application/x-freelance"
		case "prt": return "application/pro_eng"
		case "ps": return "application/postscript"
		case "psd": return "application/octet-stream"
		case "pvu": return "paleovu/x-pv"
		case "pwz": return "application/vnd.ms-powerpoint"
		case "py": return "text/x-script.phyton"
		case "pyc": return "application/x-bytecode.python"
		case "qcp": return "audio/vnd.qcelp"
		case "qd3": return "x-world/x-3dmf"
		case "qd3d": return "x-world/x-3dmf"
		case "qif": return "image/x-quicktime"
		case "qt": return "video/quicktime"
		case "qtc": return "video/x-qtc"
		case "qti": return "image/x-quicktime"
		case "qtif": return "image/x-quicktime"
		case "ra": return "audio/x-pn-realaudio"
		case "ram": return "audio/x-pn-realaudio"
		case "ras": return "application/x-cmu-raster"
		case "rast": return "image/cmu-raster"
		case "rexx": return "text/x-script.rexx"
		case "rf": return "image/vnd.rn-realflash"
		case "rgb": return "image/x-rgb"
		case "rm": return "application/vnd.rn-realmedia"
		case "rmi": return "audio/mid"
		case "rmm": return "audio/x-pn-realaudio"
		case "rmp": return "audio/x-pn-realaudio"
		case "rng": return "application/ringing-tones"
		case "rnx": return "application/vnd.rn-realplayer"
		case "roff": return "application/x-troff"
		case "rp": return "image/vnd.rn-realpix"
		case "rpm": return "audio/x-pn-realaudio-plugin"
		case "rt": return "text/richtext"
		case "rtf": return "application/rtf"
		case "rtx": return "application/rtf"
		case "rv": return "video/vnd.rn-realvideo"
		case "s": return "text/x-asm"
		case "s3m": return "audio/s3m"
		case "saveme": return "application/octet-stream"
		case "sbk": return "application/x-tbook"
		case "scm": return "application/x-lotusscreencam"
		case "sdml": return "text/plain"
		case "sdp": return "application/sdp"
		case "sdr": return "application/sounder"
		case "sea": return "application/sea"
		case "set": return "application/set"
		case "sgm": return "text/sgml"
		case "sgml": return "text/sgml"
		case "sh": return "application/x-bsh"
		case "shar": return "application/x-bsh"
		case "shtml": return "text/html"
		case "sid": return "audio/x-psid"
		case "sit": return "application/x-sit"
		case "skd": return "application/x-koan"
		case "skm": return "application/x-koan"
		case "skp": return "application/x-koan"
		case "skt": return "application/x-koan"
		case "sl": return "application/x-seelogo"
		case "smi": return "application/smil"
		case "smil": return "application/smil"
		case "snd": return "audio/basic"
		case "sol": return "application/solids"
		case "spc": return "application/x-pkcs7-certificates"
		case "spl": return "application/futuresplash"
		case "spr": return "application/x-sprite"
		case "sprite": return "application/x-sprite"
		case "src": return "application/x-wais-source"
		case "ssi": return "text/x-server-parsed-html"
		case "ssm": return "application/streamingmedia"
		case "sst": return "application/vnd.ms-pki.certstore"
		case "step": return "application/step"
		case "stl": return "application/sla"
		case "stp": return "application/step"
		case "sv4cpio": return "application/x-sv4cpio"
		case "sv4crc": return "application/x-sv4crc"
		case "svf": return "image/vnd.dwg"
		case "svr": return "application/x-world"
		case "swf": return "application/x-shockwave-flash"
		case "t": return "application/x-troff"
		case "talk": return "text/x-speech"
		case "tar": return "application/x-tar"
		case "tbk": return "application/toolbook"
		case "tcl": return "application/x-tcl"
		case "tcsh": return "text/x-script.tcsh"
		case "tex": return "application/x-tex"
		case "texi": return "application/x-texinfo"
		case "texinfo": return "application/x-texinfo"
		case "text": return "application/plain"
		case "tgz": return "application/gnutar"
		case "tif": return "image/tiff"
		case "tiff": return "image/tiff"
		case "tr": return "application/x-troff"
		case "tsi": return "audio/tsp-audio"
		case "tsp": return "application/dsptype"
		case "tsv": return "text/tab-separated-values"
		case "turbot": return "image/florian"
		case "txt": return "text/plain"
		case "uil": return "text/x-uil"
		case "uni": return "text/uri-list"
		case "unis": return "text/uri-list"
		case "unv": return "application/i-deas"
		case "uri": return "text/uri-list"
		case "uris": return "text/uri-list"
		case "ustar": return "application/x-ustar"
		case "uu": return "application/octet-stream"
		case "uue": return "text/x-uuencode"
		case "vcd": return "application/x-cdlink"
		case "vcs": return "text/x-vcalendar"
		case "vda": return "application/vda"
		case "vdo": return "video/vdo"
		case "vew": return "application/groupwise"
		case "viv": return "video/vivo"
		case "vivo": return "video/vivo"
		case "vmd": return "application/vocaltec-media-desc"
		case "vmf": return "application/vocaltec-media-file"
		case "voc": return "audio/voc"
		case "vos": return "video/vosaic"
		case "vox": return "audio/voxware"
		case "vqe": return "audio/x-twinvq-plugin"
		case "vqf": return "audio/x-twinvq"
		case "vql": return "audio/x-twinvq-plugin"
		case "vrml": return "application/x-vrml"
		case "vrt": return "x-world/x-vrt"
		case "vsd": return "application/x-visio"
		case "vst": return "application/x-visio"
		case "vsw": return "application/x-visio"
		case "w60": return "application/wordperfect6.0"
		case "w61": return "application/wordperfect6.1"
		case "w6w": return "application/msword"
		case "wav": return "audio/wav"
		case "wb1": return "application/x-qpro"
		case "wbmp": return "image/vnd.wap.wbmp"
		case "web": return "application/vnd.xara"
		case "wiz": return "application/msword"
		case "wk1": return "application/x-123"
		case "wmf": return "windows/metafile"
		case "wml": return "text/vnd.wap.wml"
		case "wmlc": return "application/vnd.wap.wmlc"
		case "wmls": return "text/vnd.wap.wmlscript"
		case "wmlsc": return "application/vnd.wap.wmlscriptc"
		case "word": return "application/msword"
		case "wp": return "application/wordperfect"
		case "wp5": return "application/wordperfect"
		case "wp6": return "application/wordperfect"
		case "wpd": return "application/wordperfect"
		case "wq1": return "application/x-lotus"
		case "wri": return "application/mswrite"
		case "wrl": return "application/x-world"
		case "wrz": return "model/vrml"
		case "wsc": return "text/scriplet"
		case "wsrc": return "application/x-wais-source"
		case "wtk": return "application/x-wintalk"
		case "xbm": return "image/x-xbitmap"
		case "xdr": return "video/x-amt-demorun"
		case "xgz": return "xgl/drawing"
		case "xif": return "image/vnd.xiff"
		case "xl": return "application/excel"
		case "xla": return "application/excel"
		case "xlb": return "application/excel"
		case "xlc": return "application/excel"
		case "xld": return "application/excel"
		case "xlk": return "application/excel"
		case "xll": return "application/excel"
		case "xlm": return "application/excel"
		case "xls": return "application/excel"
		case "xlt": return "application/excel"
		case "xlv": return "application/excel"
		case "xlw": return "application/excel"
		case "xm": return "audio/xm"
		case "xml": return "application/xml"
		case "xmz": return "xgl/movie"
		case "xpix": return "application/x-vnd.ls-xpix"
		case "xpm": return "image/x-xpixmap"
		case "x-png": return "image/png"
		case "xsr": return "video/x-amt-showrun"
		case "xwd": return "image/x-xwd"
		case "xyz": return "chemical/x-pdb"
		case "z": return "application/x-compress"
		case "zip": return "application/x-compressed"
		case "zoo": return "application/octet-stream"
		case "zsh": return "text/x-script.zsh"
	}
	
	return "text/plain"
}

func add_attachment_to_case(user, token, site, tenantID, ticket, ticketType, prevAttachments string) {
	
	url := site+"/rest/"+tenantID+"/ems/bulk/"
	
	if DEBUG {fmt.Printf(ticketType+" attachment URL: %s\n\n",url)}
	
	tempFile := filepath.Base(myResponse.Name)
	if DEBUG {fmt.Printf("tempFile = %s\n\n", tempFile)}
	
	fileinfo := strings.Split(tempFile, `.`)
	myFileName := fileinfo[0]
	myExtension := fileinfo[1]
	
	if DEBUG {fmt.Printf("Upload File is %s, Extension = %s\n\n", myFileName, myExtension)}
	
	jsonStr := []byte(`
	{
		"entities":[  
		  {  
			 "entity_type":"`+ticketType+`",
			 "properties":{  
				"Id":"`+ticket+`",       
				"`+ticketType+`Attachments":"{
					 \"complexTypeProperties\":[
						  {
							\"properties\":{ 
								\"id\":\"`+myResponse.Guid+`\",
								\"file_name\":\"`+tempFile+`\",
								\"file_extension\":\"`+myExtension+`\",
								\"size\":\"`+strconv.Itoa(myResponse.ContentLength)+`\",
								\"mime_type\":\"`+get_mimetype(myExtension)+`\",
								\"Creator\":\"`+user+`\"
							}
						  }`+prevAttachments+`
					  ]
				 }"
			 }
		  }
		],
		"operation": "UPDATE"
	}
	`)
	
	if DEBUG {fmt.Printf("add attachment to ticket, jsonStr: %s\n\n", jsonStr)}
	
    attach_reg_req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
	if err != nil {
        panic(err)
    }
    attach_reg_req.Header.Set("Cookie", "SMAX_AUTH_TOKEN="+token+";TENANTID="+tenantID)
    
    client := &http.Client{}
    attach_reg_resp, attach_reg_err := client.Do(attach_reg_req)
    if attach_reg_err != nil {
        panic(attach_reg_err)
    }
	inc_body, _ := ioutil.ReadAll(attach_reg_resp.Body)
    if DEBUG {fmt.Printf("incident attachment response Body:%s\n\n", inc_body)}
}

func main() {

	incomingArgs := os.Args[1:]
	
	if (len(incomingArgs) < 7) {
		fmt.Printf("Usage: uploadAttachment.exe <user> <password> <site> <tenantID> <ticket> <ticketType> <attachfile>\n")
		fmt.Printf("ticketType must be either 'Request' or 'Incident' and is case-sensitive\n")
		os.Exit(1)
	}
	
	user := incomingArgs[0]
	pass := incomingArgs[1]
	site := incomingArgs[2]
	tenantID := incomingArgs[3]
	ticket := incomingArgs[4]
	ticketType := incomingArgs[5]
	attachfile := incomingArgs[6]
	
	
	
	/*
	tenantID := "629195525"
	ticket := "12579"
	ticketType := "Request"
	attachfile := "c:\\test\\test.txt"
	user := "tenant_admin"
	pass := "SMAXR0cks!"
	site := "us1-smax.saas.microfocus.com"
	*/
	
	token := get_auth_token(user, pass, site, tenantID)

	previousAttachments := get_attachment_list(site, ticket, tenantID, token, ticketType)
	
	uploadStatus := upload_file(attachfile, token, site, tenantID)
	
	if uploadStatus {
		add_attachment_to_case(user, token, site, tenantID, ticket, ticketType, previousAttachments)
	} else {
		fmt.Printf("file '%s% upload failed\n", attachfile)
	}
	
	newAttachments := get_attachment_list(site, ticket, tenantID, token, ticketType)
	
	// check the current attachments for the guid of the new file uploaded
	if strings.Contains(newAttachments, myResponse.Guid) {
		fmt.Printf("Success")
	}
	
}

