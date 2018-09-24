# ADFGX

ADFGX is a Cloud Factoring Distributed Computing Application for solving Ciphers. The main focus of ADFGX is [Black Ops II's Mob of the Dead ADFGX Cipher](http://i.imgur.com/bMTtsY5.png), with the future capability to be used for many other unsolved ciphers in the Call of Duty Zombies series.

Virus Scan: https://www.virustotal.com/en/file/b43cbfb2140c1e2a3e72dce8774e74269ab12ba25bf4a34420b25d11717bfe80/analysis/1477489647/

ADFGX uses .NET Parallel to multi-thread, meaning even while running at 100% CPU usage for extended periods of time there are no performance issues or risks as the library will auto-allocate your CPU usage if other applications require the resources.

## How It Works

ADFGX receives a pre-transposed cipher from the cloud server, the first wave of this project will be working on the Mob of the Dead ADFGX Cipher transposed from the word `ZOMBIE`, which transposes to `IXSODNOIINXXSNRSNRNSRASOWXPOKXNSQL`. The reason behind starting with this substitution cipher, which is the Mob of the Dead ADFGX Cipher after being transposed, is because the extensive testing done on all possible transpositions has made it the very top possible keyword. To further this conclusion, 3 of the top individuals who work on Call of Duty Zombies ciphers came to this keyword in separate tests of their own. After either having tried all possible permutations or the data is deemed enough, ADFGX will then switch to a different transposed cipher.

For now, the alphabet key is the english alphabet shuffled randomly. This is not optimized, as it means multiple keys will be tried multiple times. This was simply to get the application out, and the information started. A future update will allocate only the permutations of the alphabet needed.

The English Ngrams used to score the returns are via [PracticalCryptography.com](http://www.PracticalCryptography.com) and provide an excellent way to score the return, with `-115` being a standard english sentence.

At any given time, you can check the top returns from the whole community on the `Top Results` page within ADFGX, chances are if you allocate a lot of your system resources and allow ADFGX to run for long periods of time, you will find yourself up there as one of the top contributors! If you plan on running the application for long periods of time, ensure that you turn off hibernation and sleeping on your machine.

## Windows

**Download:** Unavailable

Simply open `ADFGX.exe`, enter your preferred username, and click `Start`.

If you'd prefer to compile the application into an `.exe` yourself, [Visual Studio 2017](https://www.visualstudio.com/downloads/) is required.
* Clone the [ADFGX repository](https://github.com/EthanC/ADFGX)
* Open the Solution in VS2017
* Build All

## Linux / OSX

**Download:** Unavailable

Available via [Mono](http://www.mono-project.com/download/#download-lin), follow the [Mono Setup Guide](http://www.mono-project.com/archived/guiderunning_mono_applications/), enter your preferred username, and click `Start`.

A Non-GUI Console Application for UNIX servers may become available at a later time.

## Android

**Download:** Unavailable

Simply open the `ADFGX` App, enter your preferred username, and click `Start`.

## iOS

**Download:** Unavailable

Simply open the `ADFGX` App, enter your preferred username, and click `Start`.

## Thanks

Created/Maintained by: [EthanC](https://github.com/EthanC) & [TheReal_DF](https://github.com/TheRealDF)

Special Thanks:
* Oxin8
* WaterKH
* Bio-Roxas
* Certainpersonio
* Lizizadolphin
* PerferredWhale6
* [PracticalCryptography.com](http://www.practicalcryptography.com/)
