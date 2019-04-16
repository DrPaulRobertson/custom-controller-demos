// Built for Itsy Bitsy 5V 16MHz 23u4

#include "Joystick.h"

// Create Joystick
Joystick_ Joystick(JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_JOYSTICK,
2, 0,
true, true, true,
true, true, true,
true, true,
false, false, false);

const int trigPin = 9;
const int echoPin = 10;

long duration;
int distance;
int previousDistance;
int joyValue;

// Set to true to test "Auto Send" mode or false to test "Manual Send" mode.
//const bool testAutoSendMode = true;
const bool testAutoSendMode = false;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  setupJoystick();
  Serial.begin(9600);

  previousDistance = 123;
}

void setupJoystick() {

  // Set Range Values
  Joystick.setXAxisRange(-127, 127);
  Joystick.setYAxisRange(-127, 127);
  Joystick.setZAxisRange(-127, 127);
  Joystick.setRxAxisRange(0, 360);
  Joystick.setRyAxisRange(360, 0);
  Joystick.setRzAxisRange(0, 720);
  Joystick.setThrottleRange(0, 255);
  Joystick.setRudderRange(255, 0);
  
  if (testAutoSendMode)
  {
    Joystick.begin();
  }
  else
  {
    Joystick.begin(false);
  }
}

void loop() {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  duration = pulseIn(echoPin, HIGH);

  distance = duration*0.034/2.0;
  
  // Calculate axis range.
  joyValue = min(distance, 50);
  joyValue = max(joyValue, 1);
  joyValue = joyValue * 5;
  joyValue = joyValue - 127;

  Joystick.setXAxis(joyValue);

  Serial.print("Distance:");
  Serial.println(joyValue);

  if (testAutoSendMode == false)
  {
    Joystick.sendState();
  }
}
