configurar el IIS Express

#<binding protocol="http" bindingInformation="*:52064:192.168.1.108" />#

netsh http add urlacl url=http://192.168.1.108:52064/ user=todos

netsh advfirewall firewall add rule name="External Access to MyApp" dir=in action=allow protocol=TCP localport=52064