# powbot_logs
This little tool will make finding logs for your emulator or device easier. Scriptwriters greatly appreciate logs and it helps them debug/fix issues with their scripts.

_Screenshot_
![image](https://github.com/Nickert1337/powbot_logs/assets/98966743/addc104a-b7f5-4a37-a425-3ed362be9bdf)

## Getting started
1. Either download the latest release from github or compile yourself using your favourite .NET compiler.
2. Open _Powbot.Logs.exe_ and wait for the form to load.
3. Click _Refresh devices_, at this point your emulators/devices should be shown in the list. If not, goto help section below.
4. Click on your device that you'd like to see logs of, click _Refresh_ or toggle _Auto Refresh_ to start seeing logs. It is recommend to enable _Auto scroll_ which makes the logs scroll to the newest line.
5. Click _Copy_ to copy logs to your clipboard.

## Removing 'spammy' lines from the log
1. Open 'blacklisted_lines.ini' and add a part of the line you want to remove from the log. Regex can be used to match multiple lines with changing formats.
2. Restart _Powbot.Logs.exe_ to reflect the changes. Do not worry about logs being lost, they are stored within the emulator. Rebooting the application will only change what is displayed and not clear the buffers.

## Logs are huge
Logs in the emulator will stay in memory until you press the _Clear buffer_ button. If your logs are huge, pressing this button will clear the logs in the emulator. T

# Help
## Emulator or device does not show up in devices list
Usually this means ADB is not enabled, so make sure ADB is enabled.

### Enabling ADB on LDPlayer:
Open settings for the emulator you are trying to see and make sure "ADB debugging" is on "open local connection"
![image](https://github.com/Nickert1337/powbot_logs/assets/98966743/e7f736ea-1bc3-40d3-aefc-ab9fd4c411a8)


