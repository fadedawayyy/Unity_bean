# Unity_bean
Testa projekts, kas demonstrē Unity UI elementu lietojumu par tēmu "MR. Bīns"

**Darāmo darbu saraksts:**
- [x] UI Button lietojums
- [x] UI Input field lietojums
- [x] UI Text lietojums
- [x] UI Image lietojums
- [x] UI radio button lietojums
- [x] UI slider lietojums
- [x] Drag and drop funkcionalitāte
- [x] Audio source lietojums
- [x] Riggid body un collider lietojums
- [x] Projekta sagatavošana Windows OS
- [x] Izveidot galvenās izvēlnes ainu (paši)
- [x] Izveidot TV ainu (paši)
- [x] Integrēt virtuļu ķeršanas spēli
      
## TV apraksts
<img src="https://media.discordapp.net/attachments/527791626303569940/1475900285607084266/DEE27D9C-3C13-457D-86C6-3CDBFFF37813.png?ex=699f2ac0&is=699dd940&hm=874d93996baa3c9912c5b5a7a9cebcc22d61a4b833db59d5074321554c7f3a8d&=&format=webp&quality=lossless" width="700">

### Projekta apraksts
Interaktīva lietotne, kas simulē kanālu pārslēgšanu un mijiedarbību ar objektiem televizora ekrānā. Spēlētājs var pārslēgties starp divām ainām ("kanāliem"), regulēt skaļumu un aktivizēt slēptos skaņas efektus.

### Vadība un funkcionalitāte
Galvenās televizora pogas:

Pogas «1» un «2»: Pārslēgšanās starp diviem galvenajiem kanāliem.

1. kanāls: Aina ar automašīnu un policistu. Ieslēdzot automātiski sāk darboties kustības animācija un motora skaņa.
   
2. kanāls: Aina istabā ar Misteru Bīnu, lācīti Tediju un lidojošu mušu.
   
Pogas «+» / «-»: Kopējā lietotnes skaņas līmeņa regulēšana.

Poga «MUTE»: Tūlītēja visu skaņu izslēgšana vai ieslēgšana.

Poga «EXIT»: Iziešana galvenajā izvēlnē.

## Virtuļu spēle

<img src="https://cdn.discordapp.com/attachments/1389733569282314290/1475957498945994752/A7E278D4-4A62-4041-A9D1-5D3D8927FA70.png?ex=699f6009&is=699e0e89&hm=00e85d96416772fcce9c7d4b4b3ab59db7b3dde31d2726f2b566fa39b2a7405d&" width="700">

Dinamiska 2D arkādes spēle, kas izstrādāta Unity vidē. Spēlētāja uzdevums ir ķert krītošus virtuļus un izvairīties no bīstamiem priekšmetiem.

## Galvenās funkcijas
Vērtību sistēma: Dažādi virtuļu veidi dod atšķirīgu punktu skaitu (konfigurējams caur ItemValue skriptu).

Veselības mehānika: Vizuāls dzīvību attēlojums ar sirdīm, kas maina izmēru un izskatu, saņemot bojājumus.

Skaņas vadība: Fona mūzika un skaņas efekti pie priekšmetu savākšanas, spēles sākuma un zaudējuma.

Lietotāja saskarne (UI):

Sākuma izvēlne spēles uzsākšanai.

Pauzes ekrāns, nospiežot Esc.

Game Over ekrāns ar iespēju acumirklī restartēt spēli.

Adaptīva vadība: Gluda varoņa kustība ar animācijām un daļiņu efektiem (putekļi zem kājām).
