# Win10 konfigurieren

Konfiguration Client (Win10) damit mit .Net Core Client auf den MqTT Broker zugegriffen werden kann
Im Hosts(system32/drivers/etc) file den Pi eintragen:
```
192.168.1.136 raspberrypi
```

# .Net Core App 3.1
MQTT Lib: M2Mqtt 4.3.0 Library

Die Appliaktion sollte jetzt auch auf dem VS aus gestartet werden können und beim Broker auf dem Pi registrieren auf der topic mqtt_beat.
Wird eine Nachricht verschickt an mqtt_beat sollte diese auch im Debug Fenster im VS sichtbar sein


# Publish der .Net Core Anwendung auf den Pi mit Visual Studio
Auf dem Pi im Userhome ein Verzeichnis "rundotnet" erstellen. Hier können dann die Binaries publisht werden.
Mit WinScp verbinden zum Pi. 
Im Visual Studio auf dem Projekt publishen und mit WinScp in das Rundotnet Verzeichnis laden. Via Kommandozeile auf dem Pi die Applikation starten.
```
/rundotnet> dotnet ch.nevem.mqtt.simple.dll
```

Alternativ kann natürlich auch auf dem Pi mit Visual Studio Code entwickelt werden

