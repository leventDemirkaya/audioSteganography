# 🎵 Audio Steganography - Hide Secret Messages in Audio Files

> ✨ **Description:**  
> This project implements the **LSB (Least Significant Bit)** method to hide secret text messages inside **.wav** audio files using **C# .NET**.  
> The original audio quality is preserved while securely embedding hidden messages.

## 📑 Contents  
- [📜 About the Project](#about-the-project)  
- [⚡ Features](#features)  
- [🧩 Algorithm Overview](#algorithm-overview)  
- [⚙️ Installation and Usage](#installation-and-usage)  
- [📊 Sample Output](#sample-output)  
- [🛠 Technologies](#technologies)  
- [🤝 Contributing](#contributing)  
- [📄 License](#license)  
- [📬 Contact](#contact)

<a id="about-the-project"></a>
## 📜 About the Project  
Audio Steganography is a technique that hides secret messages by manipulating the least significant bits of audio files.

This project:  
- 🎙️ Processes .wav audio files  
- 🔍 Converts secret messages into binary format  
- 🌿 Uses Fibonacci sequence to embed message bits into audio data  
- 🔊 Preserves original audio quality  
- 📂 Generates new audio files containing hidden messages

<a id="features"></a>
## ⚡ Features  
- ✅ Secure message hiding using LSB method  
- ✅ Bit placement guided by Fibonacci sequence  
- ✅ Turkish character support check  
- ✅ Management of original and modified audio files  
- ✅ User-friendly Windows Forms interface
  
<a id="algorithm-overview"></a>
## 🧩 Algorithm Overview  
1. Convert audio file bytes to binary format.  
2. Convert secret message characters to binary.  
3. Use Fibonacci sequence to determine bit positions for embedding.  
4. Modify audio binary data accordingly.  
5. Convert modified binary data back to bytes and save as new .wav file.  
6. Extract and verify hidden message from modified audio.

<a id="installation-and-usage"></a>
## ⚙️ Installation and Usage  
1. 📥 Clone the repository:  
   ```bash
   git clone https://github.com/leventDemirkaya/audio-steganography.git
   cd audio-steganography
2. 💻 Open the project in Visual Studio or run with dotnet CLI.
3. 🎵 Use the Windows Forms interface to select a .wav file, enter the secret message, and embed it.
4. 🔊 Play the new audio file or extract the hidden message to verify.

<a id="sample-output"></a>
## 📊 Sample Output
### 🎙️ Selected Audio File: 
example.wav

### 📝 Secret Message: 
Merhaba, bu gizli bir mesajdır.

### 🔢 Binary Message Parts:

01001101 01100101 01110010 01101000 01100001 01100010 01100001 ...

### 🎧 Generated Audio File: 
hidden1.wav

### 📬 Extracted Message: 
Merhaba, bu gizli bir mesajdır.

<a id="technologies"></a>
## 🛠 Technologies
- 💻 C#
- 🖥 .NET Framework / .NET 6.0
- 🎨 Windows Forms
- 🎵 NAudio library

<a id="contributing"></a>
## 🤝 Contributing
Contributions are welcome!
- 🐛 Report issues via Issues
- 🚀 Submit pull requests for improvements

<a id="license"></a>
## 📄 License
This project is licensed under the MIT License. See the LICENSE file for details.

<a id="contact"></a>
## 📬 Contact
📧 leventdemirkaya@outlook.com
