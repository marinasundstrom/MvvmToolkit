# WinAppDriver

Enable ```Developer Mode``` in Windows.

Install WinAppDriver. (Download it from [here](https://github.com/microsoft/WinAppDriver))

Add Firewall rule, in order to be able to access the service from remote:

```sh
netsh advfirewall firewall add rule name="WinAppDriver remote" dir=in action=allow protocol=TCP localport=4723

```

Run WinAppDriver from the command line (substitute with your local IP address for remote access):

```sh
cd "C:\Program Files (x86)\Windows Application Driver"
./WinAppDriver.exe 127.0.0.1 4723/wd/hub
```

Then run your tests.
