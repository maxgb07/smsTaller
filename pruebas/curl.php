<?php
$ch = curl_init();

curl_setopt($ch, CURLOPT_URL, "http://192.168.8.1/api/webserver/SesTokInfo");
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

$result = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
}
//curl_close ($ch);

$xml = simplexml_load_string($result); 
print_r ($xml);

$TOKEN=$xml->TokInfo;
echo"<br/>";
echo"<br/>SessionID:".$xml->SesInfo;
echo"<br/>TokInfo:".$TOKEN;
echo"<br/>--------------------------------------------------";

$NUMBER="4433425609";
$MESSAGE="Hola desde php";
$LENGTH=strlen($MESSAGE);
$TIME=date("Y/m/d");
$SMS="<request><Index>-1</Index><Phones><Phone>".$NUMBER."</Phone></Phones><Sca/><Content>".$MESSAGE."</Content><Length>".$LENGTH."</Length><Reserved>1</Reserved><Date>".$TIME."</Date></request>";

curl_setopt($ch, CURLOPT_URL,"http://192.168.8.1/api/sms/send-sms");
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $SMS);
curl_setopt($ch, CURLOPT_POST, 1);

$headers = array();
$headers[]="Cookie: ".$xml->SesInfo;
$headers[] = "X-Requested-With: XMLHttpRequest";
$headers[] = "__requestverificationtoken:".$TOKEN;
$headers[] = "Content-Type: text/xml";

print_r ($headers);

curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

$result = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
}
curl_close ($ch);

echo "<br/> RESULTADO: ".$result;

?>