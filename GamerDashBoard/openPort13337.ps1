#==============================================================
# Creates a rule to open an incomming port in the firewall.
#==============================================================
netsh advfirewall firewall add rule name="GamerDashBoard" dir=in action=allow protocol=TCP localport=13337