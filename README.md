[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/ZKGepmmw)
# <div align='center'> 420-6A6-AB Application Development III
# <div align='center'> 420-6P3-AB Connected Objects 
# <div align='center'> Winter 2024

### <div align='center'> Final Project

# Team Information

- **Team Name:** [The Goons]
- **Team Members:**
  - [Member 1 Ryan] - [2059188]
  - [Member 2 Zakari] - [2036115]
  - [Member 3 Ron] - [2058820]

# Project Description

Our project aims to develop a sophisticated IoT solution for managing container farms using MAUI for cross-platform app development and Azure IoT for cloud infrastructure. The hardware includes a reTerminal Raspberry Pi connected to a Grove Base Hat and various sensors to simulate a mini container farm environment. This system is designed to enable efficient, automated farming within shipping containers, providing a controlled environment for optimal plant growth.

**Project Overview:**

The primary goal is to create a fully automated, remotely controlled farming system within a shipping container, referred to as a container farm. This system will be managed through a user-friendly mobile application. Users of the app, primarily fleet owners and farm technicians, will have different levels of access and permissions. Fleet owners will have full access, including the ability to monitor the geo-location and security subsystems, while farm technicians will focus on the plant management subsystem.

**Technologies Used:**

- **Hardware:** 
  - **ReTerminal Raspberry Pi:** Acts as the main computing device.
  - **Grove Base Hat and Sensors:** Includes temperature and humidity sensors, soil moisture sensors, water level sensors, fan and light controllers, GPS module, accelerometers, buzzers, noise detectors, and motion sensors.

- **Software:**
  - **Microsoft Azure IoT:** For cloud infrastructure, enabling data collection, processing, and remote control capabilities.
  - **.NET MAUI:** For developing the cross-platform mobile application, ensuring compatibility with both Android and iOS devices.

**Subsystems:**

1. **Plant Subsystem:** Monitors and controls the internal environment of the container, including temperature, humidity, soil moisture, water levels, and the state of fans and lights.
2. **Geo-location Subsystem:** Tracks the container’s location, orientation, and vibration levels, crucial for fleet management.
3. **Security Subsystem:** Ensures the safety and security of the container, monitoring access and environmental conditions such as noise levels, luminosity, and motion detection.

**User Interaction:**

Users launch the app to either sign up or log in. Depending on their role, they access different functionalities:
- **Fleet Owners:** Can monitor all deployed containers, manage security and geo-location subsystems, and receive alerts for suspicious activities.
- **Farm Technicians:** Focus on managing plant conditions within the container, ensuring optimal growing conditions through remote monitoring and control.

This project not only leverages advanced IoT and cloud technologies but also emphasizes user-friendly design and robust security measures, aiming to revolutionize container farming with automated, precise, and efficient agricultural solutions.

# Contributions

| Team Member | Contribution | Work Division |
|-------------|--------------|---------------|
| Member 1 Ryan | Firebase collection of all containers, live status checker on all containers, organization of code (Models, ViewModels, and DataRepos), Displaying data on all subsystems, Connection status checker mid-program, Readme MS7, app re-modeling  | Plant Subsystem |
| Member 2 Zakari | Firebase collection on user authentification and their roles, Contribution for Login and Sign Up page, displaying graph for the plant subsystem, displaying information for security, Documentation and UML Diagram| Security Subsystem |
| Member 3 Ron | azure iot service setup in services folder and in azure website (Iothub communication for sending and receiving messages), contribution for dashboard and subsystem pages, implementation of map advanced view  | Geo-Location Subsystem |

# Connected Objects
# Device Configuration for Farm System

## GPIO Connection Table

### Plant Subsystem

| Device         | Type    | Port      |
| -------------- | ------- | --------- |
| Temperature Sensor | Sensor | GPIO17    |
| Humidity Sensor    | Sensor | GPIO18    |
| Fan                | Actuator | GPIO21  |
| LED                | Actuator | GPIO22  |
| Moisture Sensor                | Sensor | A2  |
| Water Sensor                | Sensor | A0  |

### Security Subsystem

| Device         | Type    | Port      |
| -------------- | ------- | --------- |
|  Micro Servo | Actuator |GPIO05|
| Noise Detector    | Sensor | GPIO02    |
| Magnetic door                | Sensor | GPIO05  |
| Motion Sensor      | Sensor | GPIO22  |


### Geo Subsystem

| Device         | Type    | Port      |
| -------------- | ------- | --------- |
|  Accelerometer pitch | Sensor |N/A|
|  Accelerometer vibrations    | Sensor | N/A    |
| GPS                | Sensor | ttyAMA0  |
| Buzzer                | Actuator | GPIO01  |

### Controlling Actuators

| Device           | Communication      |
| --------------- | --------- |
|  Buzzer  |C2D Messages|
|   Micro Servo    | C2D Messages    |
| Fan                | C2D Messages  |
| LED                 | C2D Messages  |

### Buzzer
#### Strategy: C2D messages
#### Reason: C2D MESSAGES over Device Twins and Direct methods align with the buzzer's need for immediate response and reliability in emitting sounds within the container farm. While Device Twins excel in managing device metadata, they lack the real-time responsiveness crucial for the buzzer's timely alerts. Additionally, Direct methods necessitate constant connectivity, potentially leading to delays or unreliability, making C2D the superior choice for this vital actuator.

Turn BUZZER to ON: Command setting Type.BUZZER to {"value": "on"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "buzzer", "value": "on"}`
`

Turn BUZZER to OFF: Command setting Type.BUZZER to {"value": "off"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "buzzer", "value": "off"}`
`

###  Micro Servo 
#### Strategy: C2D messages
#### Reason: C2D MESSAGES instead of Device Twins and Direct methods are apt for the micro servo's role in automatically locking doors within the container farm. While Device Twins facilitate metadata management, they lack the instantaneous control required for securing doors promptly. Furthermore, Direct methods' dependency on constant connectivity may introduce delays or reliability issues, underscoring C2D's suitability for ensuring swift and dependable door-locking mechanisms.

turn SERVO to MIN: Command setting Type.SERVO to {"value": "min"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "servo", "value": "min"}'
`

turn SERVO to Mid: Command setting Type.SERVO to {"value": "mid"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "servo", "value": "mid"}'
`

turn SERVO to Max: Command setting Type.SERVO to {"value": "max"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "servo", "value": "max"}'
`

### Fan
#### Strategy: C2D messages
#### Reason: C2D MESSAGES over Device Twins and Direct methods is fitting for the fan's task of maintaining stable temperatures within the container farm. While Device Twins effectively manage device metadata, they lack the immediacy needed for real-time temperature control. Moreover, Direct methods' reliance on continuous connectivity may introduce latency or instability, emphasizing C2D's appropriateness for ensuring consistent and timely temperature regulation.

Set FAN to True: Command setting Type.FAN to {"value": "1"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "fan", "value": "1"}`

Set FAN to False: Command setting Type.FAN to {"value": "0"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "fan", "value": "0"}`



###  LED  
#### Strategy: C2D messages
#### Reason: C2D MESSAGES instead of Device Twins and Direct methods is pertinent for the LED's function of providing light within the container farm. While Device Twins excel in managing device metadata, they lack the instantaneous control required for timely lighting adjustments. Additionally, Direct methods' reliance on uninterrupted connectivity may introduce delays or inconsistencies, highlighting C2D's relevance in ensuring prompt and reliable lighting operations.

Set LED to OFF Command setting Type.LIGHT_ON_OFF to {"value": "0"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "ledStrip", "value": "0"}'`

Set LED to ON Command setting Type.LIGHT_ON_OFF to {"value": "1"}

`az iot hub invoke-device-method --hub-name {iothub_name} --device-id {device_id} --method-name control_actuator --method-payload '{"type": "ledStrip", "value": "1"}'
`
## Mobile App

### App Overview

Provides a descriptive summary of the app. [250 words maximum]

- **Features and Functionality:**
  - Feature 1
  - Feature 2
  - Feature 3

This section includes snapshots of the final app showing different features with explanatory captions.

### App UML Diagram

Display an updated version of your UML diagram to explain your models:

- Focus on the most important models
- Clearly identify public and private properties
- Clearly identify the nature of the links between models if it is important to understand your app
- No need to include code behind classes

### App Setup

Include all setup instructions and configurations needed to run the app with any IoT hub. This includes instructions on used connection strings and how to acquire them.

- **IoT Hub:** "IoTHubConnectionString": "HostName=IoTRyanmeziane.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=llqmw64mnjUuz6AR7q6KDsiDr0kbDj0wZAIoTOweiP8=", "EventHubConnectionString": "Endpoint=sb://goonscontainer.servicebus.windows.net/;SharedAccessKeyName=iothubroutes_IoTRyanmeziane;SharedAccessKey=QZd3Mt1oVSPp4huhWJJFTYe66V+5zkfH8+AEhMmRJM8=;EntityPath=thegoons", "EventHubName": "thegoons" 
- **Authentication:** Firebase connections for auth: "FireBaseAuthDomain": "egoon-e1275.firebaseapp.com", "FireBaseApiKey": "AIzaSyA2gKmFTZU-CUtIgav7MLmiC_IGVqrfukQ",
- **Database (if used):** Firebase connections: "RealtimeDatabase": "https://egoon-e1275-default-rtdb.firebaseio.com/", "FireBaseApiKey": "AIzaSyA2gKmFTZU-CUtIgav7MLmiC_IGVqrfukQ", "FireBaseAuthDomain": "egoon-e1275.firebaseapp.com" NOTE: ALL THESE URLS MUST BE STORED WITHIN THE APPSETTINGS.JSON FILE AT THE ROOT OF THE PROJECT.

## Future Work

NA

## Bonus Features

### Update of GitHub Issues

Some Github issues have been updated.

### Would-like-to-develop Features

NA, Features have changed like container status but no notification page yet.

### Bonus Features

#### Use of Storage in IoT Hub

- **Storage Type:** Firebase
- **Explanation:** Since we had previous experience with firebase it was easy to implement it to manage our containers on our app. Futhermore, it allowed it to use CRUD methods (only create, read, and delete) which helped us keep track of the IoT Devices.
- **Technical Details/Advanced Configuration:** NA
- **Snapshots:**
  ![image](https://github.com/JAC-Final-Project-W24-6A6-6P3/final-project-the-goons/assets/77261159/5dd7b14e-95ba-45b6-b31b-eae8179f04f5)


#### Support for Multiple Containers

- **Description:** As many devices as the user wants. Our way of managing new devices is through the container list and keeping track of the deviceId throughout the app unless changed by going back to the list and selecting another. Firebase also helps manage these containers so they can be available to the entire team of fleet owners and or technicians.
- **Message Management:** Our solution is to track the selected container Id throughout the app and ONLY displaying data associated with the desired container.
- **Requirements:** With the proper firebase set up and fault handling our app can hold as many containers as possible. However if many containers (devices) are on the same IoT Hub it may because hard for the device to handle information coming in constantly and will require futher optimization.

#### User-defined Controls

- **Explanation:** This feature is extremely useless for users to know when a device is available for reading or not. If the device is on the code behind checks and verifies that the device is truely on before continuing. If the device is then shut off mid application use (past the container selection page) It will re-direct them back to the selection page.
- **Testing Instructions:** To test this feature simply disconnect the device (stop the farm.py script or shut of the device) and watch the status change within 5 seconds. The image below shows the device offline.
- **Snapshots:**
  ![image](https://github.com/JAC-Final-Project-W24-6A6-6P3/final-project-the-goons/assets/77261159/1e459846-b16e-473a-a644-6f6e624bd063)

