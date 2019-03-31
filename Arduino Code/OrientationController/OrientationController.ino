// Built for Itsy Bitsy 5V 16MHz 23u4

#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>

String testString = "Hello world";

// Setup sensor reading for imu
#define BNO055_SAMPLERATE_DELAY_MS (50)
Adafruit_BNO055 bno = Adafruit_BNO055(55);

void setup() {
  Serial.begin(115200);
  Serial.println();

  // setup imu sensor
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }

  delay(1000);

  bno.setExtCrystalUse(true);
}

void loop() {
  /* Get a new sensor event */
  sensors_event_t event;
  bno.getEvent(&event);

  imu::Quaternion quat = bno.getQuat();
  imu::Vector<3> gravity = bno.getVector(Adafruit_BNO055::VECTOR_GRAVITY);
  testString = String(quat.x(), 4) + ";" + String(quat.y(), 4) +";"+ String(quat.z(), 4) +";"+ String(quat.w(), 4) +";"+ String(gravity.x()) +";"+ String(gravity.y()) +";"+ String(gravity.z());
  //testString = String(gravity.x()) +";"+ String(gravity.y()) +";"+ String(gravity.z());

  Serial.println(testString);

  /* Wait the specified delay before requesting nex data */
  delay(BNO055_SAMPLERATE_DELAY_MS);
  
}
