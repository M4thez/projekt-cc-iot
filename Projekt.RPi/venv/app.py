
from flask import Flask
import json
import time
import datetime
from json import JSONEncoder
import Adafruit_DHT
sensor = Adafruit_DHT.DHT11
pin = 4

app = Flask(__name__)



@app.route('/')
# ‘/’ URL is bound with hello_world() function.
def hello_world():
    humidity, temperature = Adafruit_DHT.read_retry(sensor, pin)
    #humidity = 45.3
    #temperature = 22.5
    print('Temp={0:0.1f}*C Humidity={1:0.1f}%'.format(temperature, humidity))
    print(temperature)
    print(humidity)
    time.sleep(10)

    class DateTimeEncoder(JSONEncoder):
        def default(self, obj):
            if isinstance(obj, (datetime.date, datetime.datetime)):
                return obj.isoformat()

    temp_hum = {
        "TemperatureC": temperature,
        "Humidity": humidity,
        "DateMeasured": datetime.datetime.now()
    }

    temp_hum_json = json.dumps(temp_hum, indent=4, cls=DateTimeEncoder)

    return temp_hum_json


# main driver function
if __name__ == '__main__':
    # run() method of Flask class runs the application
    # on the local development server.
    app.run(debug=True, host='0.0.0.0')