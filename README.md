STM32F4_RF
=================

Project based on radio communication between two adapters. 
Our focus was to check range of signal smaller than 3m, depending on different parameters.
Practical use is showed by a game(,,Radio Plane" in C#) which can be controlled by radio signal(specified in STM32F4_RF_STM_PING project compiled and downloaded on for ex. STM32F407VG).
All files are provided and STM projects use only standard CooCox library files(including UART), besides XNA environment for a game project.

Goals of this project:
* Check ranges of signals between two adapters depending on different parameters.
* Show practical usage of this kind of connection.

IDE and Compiler Setup
----------------------

STM projects are build with CooCox IDE. Others are Visual Studio 2012 projects with .NET Framework 4.5 (recommended to use 4.0 or above).

Drivers and Utilities for the STM32F4xx
---------------------------------------

Here are drivers for STM32F4xx: http://www.st.com/web/en/catalog/tools/PF258167

You might also download ARM-GCC compiler(besides CooCox IDE) from: https://launchpad.net/gcc-arm-embedded/+download

Building and Running the Code
-----------------------------

Radio Plane(you have to have XNA environment installed and configured)
* Build/Debug: Load the project in Visual Studio 2012(or newest version), click Debug(or F5)
* Test: Hook a USB Radio Adapter(ex.MOBOT RCR-V2). The device should show up as a virtual com port. Program automatically detects first connected COM and uses it as a default device. In settings you can choose if you control game by radio or keys. For radio to work you need to use adapter connected to STM device(most preferable STM32F407VG) with compiled and downloaded STM32F4_RF_STM_PING project.

STM32F4_RF_MOBOT
* Build/Debug: Load the project in Visual Studio 2012(or newest version), click Debug(or F5)
* Test: Application allows you to test radio connection between computer with radio adapter and STM with radio adapter or module imitating radio connection for STM(connected to computer). Needs manual enteries of com devices. 

STM32F4_RF_PROG
* Build/Debug: Load the project in Visual Studio 2012(or newest version), click Debug(or F5)
* Test: Application allows you to test radio connection depending on parameters you choose. Automatically detects connected com devices. Tip: don't write your own text, when values from list are available.

STM32F4_RF_STM
* Build: Load the project in CooCox IDE. Click Build.
* Program: Download program on STM device.
* Test: Connect two radio adapters or COM device(connected to STM) that imitates connection. You need to Build/Debug STM32F4_RF_MOBOT and choose appropriate COM, after that you can write commands in console(specified in MOBOTmanual.txt). These programs require actual changes in code to work together, so basic knowledge of UART for STM and your radio adapter is required. Mostly recommended usage of MOBOT radio devices.

STM32F4_RF_STM_PING
* Build: Load the project in CooCox IDE. Click Build.
* Program: Download program on STM device.
* Test: Working together with Radio Plane. You can also check what data is sent with usage of STM32F4_RF_PROG(basic parameters: transfer speed 50000 bps, channel 0, 8bit).

Debugging
---------
CooCox is the in-circuit debugger via the ST-LINK works out of the box.  Click the little bug icon, wait a few seconds, and you've breakpoints in a live embedded device. 

Visual Studio has his own enough clear debugger, so it doesn't need more description. =)

Future changes
--------------
Clear out all unused and not needed code. Add more comments to code, where explanation is needed. 


Helpful sites
-------------
Example of USART usage: http://gpio.kaltpost.de/?page_id=167

Example of code used to handle Radio Adapters in C#: https://www.dropbox.com/s/oepzl5f9h2x6kw3/Com%20Send.txt

Example of code used to handle Radio Adapters in CooCox IDE: https://www.dropbox.com/s/vdr20sf5xpxkkpp/USART.txt