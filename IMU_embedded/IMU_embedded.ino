#include <SparkFunLSM6DS3.h>
#include "Wire.h"
#include "SPI.h"

LSM6DS3 myIMU;
float accel_x, accel_y, accel_z;
float pitch, roll;
float filter_x, filter_y, filter_z;
const float alpha = 0.5;
bool sync_flag;
bool start_flag;

void setup() {
  sync_flag = false;
  start_flag = false;
  Serial.begin(9600);
  delay(1000); //relax...
  Serial.println("Processor came out of reset.\n");
  myIMU.begin();
}

void get_accel(){
  accel_x = myIMU.readFloatAccelX();
  accel_y = myIMU.readFloatAccelY();
  accel_z = myIMU.readFloatAccelZ();
}

void calc_euler(){
  filter_x = accel_x * alpha + (filter_x*(1.0-alpha));
  filter_y = accel_y * alpha + (filter_y*(1.0-alpha));
  filter_z = accel_z * alpha + (filter_z*(1.0-alpha));
  roll = (atan2(-filter_y, filter_z)*180) / 3.14159;
  pitch = (atan2(filter_x, sqrt(filter_y*filter_y + filter_z*filter_z))*180)/3.14159;
  
}
void loop() {
  String data_in;
  if(Serial.available()> 0){
    data_in = Serial.readString();
  }
  if(!sync_flag){
    if(data_in == "sync"){
      Serial.println("ack");
      sync_flag = true;
    }
  }
  else{
    if(data_in == "send"){
      get_accel();
      calc_euler();
      Serial.println(String(roll) + "," + String(pitch));
    }
  }
  
  // put your main code here, to run repeatedly:
  //Serial.println("X: " + String(9.8*accel_x) + " Y: " + String(9.8*accel_y)+ " Z: " + String(9.8*accel_z));
  //Serial.println("roll: " + String(roll) + " pitch: " + String(pitch));
  
} 
