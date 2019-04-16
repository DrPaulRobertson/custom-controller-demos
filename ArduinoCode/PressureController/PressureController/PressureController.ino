// Built for Itsy Bitsy 5V 16MHz 23u4

#include "Joystick.h"

int leftPin = 1;
int leftReading;
int rightPin = 2;
int rightReading;

Joystick_ joystick(JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_JOYSTICK,
2, 0,
true, true, true,
true, true, true,
true, true,
false, false, false);
const bool autoSend = false;

void setup() {
  setupJoystick();
  Serial.begin(9600);
}

void loop() {
  leftReading = (int)analogRead(leftPin);
  rightReading = (int)analogRead(rightPin);
  Serial.print("Flex reading: ");
  Serial.print(leftReading);
  Serial.print(", ");
  Serial.println(rightReading);

  leftReading = map(leftReading, 0, 1000, 512, 1023);
  rightReading = map(rightReading, 0, 1000, 512, 1023);

  joystick.setXAxis(leftReading);
  joystick.setYAxis(rightReading);
  //joystick.setThrottle(flexReading);
  Serial.print("Joystick value: ");
  //Serial.println(flexReading);

  if (autoSend == false)
  {
    joystick.sendState();
  }
}

void setupJoystick() {

  // Set Range Values
  joystick.setXAxisRange(0, 1024);
  joystick.setYAxisRange(0, 1024);
  joystick.setZAxisRange(-127, 127);
  joystick.setRxAxisRange(0, 360);
  joystick.setRyAxisRange(360, 0);
  joystick.setRzAxisRange(0, 720);
  joystick.setThrottleRange(0, 255);
  joystick.setRudderRange(255, 0);

  joystick.setXAxis(512);
  joystick.setYAxis(512);
  joystick.setZAxis(0);
  joystick.setRxAxis(0);
  joystick.setRyAxis(0);
  joystick.setRzAxis(0);
  joystick.setThrottle(0);
  joystick.setRudder(0);
  
  if (autoSend)
  {
    joystick.begin();
  }
  else
  {
    joystick.begin(false);
  }
}
