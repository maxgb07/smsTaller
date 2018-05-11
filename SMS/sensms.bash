RESPONSE=`curl -s -X GET http://192.168.8.1/api/webserver/SesTokInfo`
COOKIE=`echo "$RESPONSE"| grep SessionID=| cut -b 10-147`
TOKEN=`echo "$RESPONSE"| grep TokInfo| cut -b 10-41`
NUMBER="4433425609"
MESSAGE="Clutch y Frenos Anguiano le notifica por este medio que su vehiculo esta listo y puede recogerlo, el total de la reparacion es de: $ 999.00 pesos."
DATA="<?xml version='1.0' encoding='UTF-8'?><request><Index>-1</Index><Phones><Phone>$NUMBER</Phone></Phones><Sca></Sca><Content>$SMS</Content><Length>11</Length><Reserved>1</Reserved><Date>-1</Date></request>"

LENGTH=${#MESSAGE}
TIME=$(date +"%Y-%m-%d %T")


SMS="<request><Index>-1</Index><Phones><Phone>$NUMBER</Phone></Phones><Sca/><Content>$MESSAGE</Content><Length>$LENGTH</Length><Reserved>1</Reserved><Date>$TIME</Date></request>"



PRUEBA=`curl -v -b "$COOKIE" -c "$COOKIE" -H "X-Requested-With: XMLHttpRequest" --data "$SMS" http://192.168.8.1/api/sms/send-sms --header "__RequestVerificationToken: $TOKEN" --header "Content-Type:text/xml"`

echo $PRUEBA > "D:\Escritorio\prueba.txt"
