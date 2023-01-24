import numpy as np
import matplotlib.pyplot as plt

t = np.linspace(0, 2, 2 * 100)

sine_wave = np.sin(10 * 2 * np.pi * t)
cosine_wave = np.cos(10 * 2 * np.pi * t)

sine_fourier = np.fft.fft(sine_wave)
cosine_fourier = np.fft.fft(cosine_wave)

plt.figure()
plt.subplot(211)
plt.plot(t, sine_wave)
plt.xlabel('Time (s)')
plt.ylabel('Amplitude')
plt.title('Sine Wave')

plt.subplot(212)
plt.plot(np.abs(sine_fourier))
plt.xlabel('Frequency (Hz)')
plt.ylabel('Amplitude')
plt.title('Fourier Transform of Sine Wave')

plt.figure()
plt.subplot(211)
plt.plot(t, cosine_wave)
plt.xlabel('Time (s)')
plt.ylabel('Amplitude')
plt.title('Cosine Wave')

plt.subplot(212)
plt.plot(np.abs(cosine_fourier))
plt.xlabel('Frequency (Hz)')
plt.ylabel('Amplitude')
plt.title('Fourier Transform of Cosine Wave')

plt.show()
plt.title('Cosine Wave')

plt.subplot(212)
plt.plot(np.abs(cosine_fourier))
plt.xlabel('Frequency (Hz)')
plt.ylabel('Amplitude')
plt.title('Fourier Transform of Cosine Wave')

plt.show()