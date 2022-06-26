import json
import requests
import time
import datetime
import RPi.GPIO as GPIO
from json import JSONEncoder
import Adafruit_DHT

sensor = Adafruit_DHT.DHT11
pin = 4
target_temp = 20

LED1_PIN = 17
LED2_PIN = 27
LED3_PIN = 22
MOTOR_PIN = 26

GPIO.setmode(GPIO.BCM)
GPIO.setup(LED1_PIN, GPIO.OUT)
GPIO.output(LED1_PIN, GPIO.LOW)

GPIO.setmode(GPIO.BCM)
GPIO.setup(LED2_PIN, GPIO.OUT)
GPIO.output(LED2_PIN, GPIO.LOW)

GPIO.setmode(GPIO.BCM)
GPIO.setup(LED3_PIN, GPIO.OUT)
GPIO.output(LED3_PIN, GPIO.LOW)

GPIO.setmode(GPIO.BCM)
GPIO.setup(MOTOR_PIN, GPIO.OUT)
GPIO.output(MOTOR_PIN, GPIO.LOW)


while(True):
    humidity, temperature = Adafruit_DHT.read_retry(sensor, pin)
    #humidity = 45.3
    #temperature = 22.5
    print('Temp={0:0.1f}*C Humidity={1:0.1f}%'.format(temperature, humidity))

    class DateTimeEncoder(JSONEncoder):
        def default(self, obj):
            if isinstance(obj, (datetime.date, datetime.datetime)):
                return obj.isoformat()

    temp_hum = {
        "TemperatureC": temperature,
        "Humidity": humidity,
        "DateMeasured": str(datetime.datetime.now())
    }

    requests.post(
        'https://projekt-cc-iot.azurewebsites.net/api/measurements', json=temp_hum)

    target_temp = requests.get(
        'https://projekt-cc-iot.azurewebsites.net/api/control/last')
    target_temp_json = json.loads(target_temp.text)
    print(target_temp_json['controlTemperature'])

    if humidity <= 50:
        GPIO.output(LED1_PIN, GPIO.HIGH)
        GPIO.output(LED2_PIN, GPIO.LOW)
    else:
        GPIO.output(LED1_PIN, GPIO.LOW)
        GPIO.output(LED2_PIN, GPIO.HIGH)

    if temperature > float(target_temp_json['controlTemperature']):
        GPIO.output(MOTOR_PIN, GPIO.HIGH)
    else:
        GPIO.output(MOTOR_PIN, GPIO.LOW)

    time.sleep(30)
