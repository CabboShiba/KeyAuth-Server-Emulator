# Keyauth-Server-Emulator
Original meant as bypass, I tought it was better to define it a "Server Emulator". By Cabbo 

# Emulator

With this LocalHost Server (C#), you can emulate every features from KeyAuth Original Client. 

# How it works

KeyAuth Loader > HTTP Request > HTTP Request intercepted and tampered by my Server > Response Emulation > Response Crypting > Sending fake response > De-Crypting Response > Positive Response > Success : True. 

That's not a real bypass, as I only emulate the real KeyAuth Server with the Application Secret. 
For this, you need Application Secret, which can be bruteforced with an integrated BruteForce-System during InitIV Request. 

Info about Application Secret: 
Application Secret is a 64-Length String. You can grab it from Process Hacker 2,ad after BruteForce it. 

Obfuscators like VMProtect 3.6.0 (Max settings. Virtualization enabled) or .NET Reactor 6.8.0 (Max settings. Virtualization enabled) can not stop this process, or hide the Secret. 

# Info

Realized on 21-08-2022, and published on this repository: https://github.com/CabboShiba/KeyAuth-HTTP-Bypass

Decided to move it in a new repository. 

# ShowCase


![image](https://user-images.githubusercontent.com/92642446/188995437-793b3569-3a15-4b8b-bfdd-eeebab11a5bb.png)

Init and Login request intercepted and tampered by my LocalHost Server.

# Emulator Release

Never lmao, skids would really abuse of it as it's really easy to use and really powerful. 

# Contact Me

Do you want to contact me? 

Discord: FreeCabbo10#6558

Telegram: https://t.me/cabboshiba

# License 

Repostory and Bypass under License GNU General Public License, version 3 (GPLv3).

Made by Cabbo on 21-08-2022.


