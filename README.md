# DashBoard

ALPHA Preview
![Alt text](GamerDashBoard/alpha_preview.png)


##Introduction
This is a Net.ASP webpage which allows monitoring of a local PC. It displays information about the user's PC hardware on a wi-fi-enabled smartphone. A G910 (Logitech) combined with a medium to large sized smartphone screen works great for this purpose.

Planned modules:
	- Hardware
	- Teamspeak 3
	
If you like it and want to support the project, feel free to give a small donation! : ) <br>
[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=SVW78SGP7EZAJ)


##Current available APIs
There are some APIs that can be used independently from the frontend.
Apis that work for now:

- api/hardwareinfo/
- api/raminfo/
- api/networkinfo/
- api/cpuinfo

###Example:
http://localhost:13337/api/hardwareinfo

will deliver
```
{
    "networkInfo": {
        "kbitIn": 0,
        "kbitOut": 1.10915112
    },
    "ramInfo": {
        "available": 9944,
        "max": 16321.375
    },
    "cpuInfo": {
        "cpuLoadMap": {
            "0,6": 8.005339,
            "_Total": 7.66567,
            "0,4": 4.6487875,
            "0,5": 12.46698,
            "0,2": 24.13788,
            "0,3": 5.92857,
            "0,1": 0.3285299,
            "0,0": 11.1387882,
            "0,7": 4.85397
        },
        "numberCores": 8
    }
}
```
http://localhost:13337/api/raminfo/
will deliver
```
{
    "available": 9948,
    "max": 16321.375
}
```

http://localhost:13337/api/teamspeakinfo
will deliver
```
{
    "myChannel": {
        "id": "16",
        "name": "Stammtisch",
        "clients": {
            "2": {
                "id": "2",
                "nickname": "Scratch",
                "isTalking": false,
                "client_status": "normal"
            },
            "5": {
                "id": "5",
                "nickname": "britnex",
                "isTalking": false,
                "client_status": "normal"
            }
        }
    },
    "myClient": {
        "id": "13",
        "nickname": "Greeve",
        "isTalking": false,
        "client_status": "normal"
    }
}
```

##Installation
There is no automatic installer yet, it's on the ToDo List!

###Requirements
- .Net Framework 4.5
- Administrator previleges

###Installation Process

- Run Visual Studio as Admin -> Load project -> Run GamerDashBoard
- Access http://localhost:1337/DashBoard.html

A detailed description will follow later.

##Progress

###Done
* Apis: 
  * CPU 100%
  * Memory 100%
  * Network 90%
  * Teamspeak 100*
* Frontend
  * CPU 100%
  * Memory 100%
  * Network 100%
  * Teamspeak 30*

###In progress
* Settings Screen 0%
  * Change Wallpaper 0%
  * Change Color Schema 0%
  * Change TS3 Display Settings 0%
* Standalone Installer 10%

##Credits

Special thanks to:
- Nikola  Sivkov
- Bayne
- Wulf 
- Sebbi 
- Denyo 
- UmCaP Crew
for helping me getting shit done!!!
(and Logitech for this awesome Keyboard, that inspired me!)