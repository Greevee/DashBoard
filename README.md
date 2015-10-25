# DashBoard
Little ASP.Net Site, that shows some infos

Current available APIS

- api/hardwareinfo/
- api/raminfo/
- api/networkinfo/


Example:
http://localhost:59136/api/hardwareinfo

will deliver

{
    "networkInfo": {
        "kbitIn": 0.127643734,
        "kbitOut": 0.117000565
    },
    "ramkInfo": {
        "available": 10569,
        "max": 16322.2266
    },
    "cpuInfo": {
        "cpuLoadMap": {
            "0,6": 0.274487168,
            "_Total": 14.8175249,
            "0,4": 13.754487,
            "0,5": 17.0716228,
            "0,2": 13.7545977,
            "0,3": 13.5710564,
            "0,_Total": 14.9987793,
            "0,1": 3.59865046,
            "0,0": 26.86794,
            "0,7": 30.1920071
        }
    }
}