# powbot_logs
This little tool will make finding logs for your emulator or device easier. Providing these logs to scriptwriters allows them to debug/fix issues with their scripts much quicker and is greatly appreciated.

![image](https://github.com/user-attachments/assets/18af080e-d4b9-4519-9355-dccc3af35568)

## Getting started
1. Either download the [latest release](https://github.com/Nickert1337/powbot_logs/releases) from github or compile the source code yourself using your favourite .NET compiler.
2. Open `Powbot.Logs.exe` and wait for the form to load.
3. Click `Refresh devices`.<br/>
   _At this point your emulators/devices should be shown in the list. If not, proceed to the help section below._
4. From the device list, click on the device for which you'd like to view the logs
5. Click `Refresh` or toggle `Auto refresh` to start seeing logs.
6. Click `Copy` to copy logs to your clipboard.

> Enabling _Auto scroll_ is highly recommended as it makes the logs scroll to the newest line.

## Streaming all emulator logs to seperate files

1. Check the _Automatically log all emulator logs to separate files_ option in the GUI.
2. A folder named `logs` will be created in your `powbot_logs` directory.
3. Ensure all emulators are listed in the devices list.
4. For each emulator in the devices list, a `.txt` file will be created in the `logs` folder.
5. Logs produced by these emulators will be automatically appended to their respective `.txt` files.

> You should regulary clean these files as new logs will just be appended to the old `.txt` files.

## Ignoring "spammy" log messages
1. Edit the `blacklisted_lines.ini` file by inserting a new line for each phrase that you would like to ignore.<br/>
   _Regex can be used to match multiple lines with changing formats._
2. Restart `Powbot.Logs.exe` to reflect the changes.<br/>
   _Logs will not be lost - they will be displayed again once you reconnect_

## Clearing logs
Logs in the emulator will stay in memory until you press the `Clear buffer` button. If your logs are huge, pressing this button will clear the logs in the emulator.

## Common Issues

<details>
  <summary>Emulator or device does not show up in devices list</summary>
  <br/>
  Usually this means ADB is not enabled, so make sure ADB is enabled.
  <br/>
  <br/>
  <details>
    <summary>How to enable ADB on LDPlayer</summary>
    <br/>
    Open settings for the emulator you are trying to see and make sure <code>ADB debugging</code> is on <code>open local connection</code>
    <br/>
    <br/>
    
  ![image](https://github.com/Nickert1337/powbot_logs/assets/98966743/e7f736ea-1bc3-40d3-aefc-ab9fd4c411a8)
  </details>
  
</details>
