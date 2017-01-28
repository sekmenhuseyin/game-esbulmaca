Public Class Form1
    'Korh@N GeRi� prestige 2005 

    'resimler �nce pictureboxlara sonra da diziye al�narak kullan�l�yor..
    'default 2 resim i�in form a��l�yor sonradan menustrip ile de�i�tirilebiliyor

#Region "global de�i�kenler"
    't�klanan son eleman� tut
    Dim tut As String = ""
    ' eleman� bo�altmak i�in tan�mlad�m
    Dim bos_image As Image
    'b1_click te sender ile kimin bast���n� anl�yoruz
    Dim eleman�_al As Integer
    Dim deger1, deger2 As Integer
    Dim zaman As Integer = 0
    Dim dizi_image(17) As Image
    Dim dizi_butonlar(5, 5) As Button
    Dim kac_resimle_oyna As Integer = 2

#End Region

#Region "prosed�rler"

    Private Sub butonlar()
        'butonlar diziye al�nd�
        dizi_butonlar(0, 0) = b1
        dizi_butonlar(0, 2) = b3
        dizi_butonlar(0, 4) = b5
        dizi_butonlar(0, 1) = b2
        dizi_butonlar(0, 3) = b4
        dizi_butonlar(0, 5) = b6
        dizi_butonlar(1, 0) = b7
        dizi_butonlar(1, 2) = b9
        dizi_butonlar(1, 4) = b11
        dizi_butonlar(1, 1) = b8
        dizi_butonlar(1, 3) = b10
        dizi_butonlar(1, 5) = b12
        dizi_butonlar(2, 0) = b13
        dizi_butonlar(2, 2) = b15
        dizi_butonlar(2, 4) = b17
        dizi_butonlar(2, 1) = b14
        dizi_butonlar(2, 3) = b16
        dizi_butonlar(2, 5) = b18
        dizi_butonlar(3, 0) = b19
        dizi_butonlar(3, 2) = b21
        dizi_butonlar(3, 4) = b23
        dizi_butonlar(3, 1) = b20
        dizi_butonlar(3, 3) = b22
        dizi_butonlar(3, 5) = b24
        dizi_butonlar(4, 0) = b25
        dizi_butonlar(4, 2) = b27
        dizi_butonlar(4, 4) = b29
        dizi_butonlar(4, 1) = b26
        dizi_butonlar(4, 3) = b28
        dizi_butonlar(4, 5) = b30
        dizi_butonlar(5, 0) = b31
        dizi_butonlar(5, 2) = b33
        dizi_butonlar(5, 4) = b35
        dizi_butonlar(5, 1) = b32
        dizi_butonlar(5, 3) = b34
        dizi_butonlar(5, 5) = b36
    End Sub

    Private Sub resimler()
        'pictureboxlarda ki resimler image dizisine aktar�l�yor
        dizi_image(0) = resim1.Image
        dizi_image(2) = resim3.Image
        dizi_image(1) = resim2.Image
        dizi_image(3) = resim4.Image
        dizi_image(4) = resim5.Image
        dizi_image(5) = resim6.Image
        dizi_image(6) = resim7.Image
        dizi_image(7) = resim8.Image
        dizi_image(8) = resim9.Image
        dizi_image(9) = resim10.Image
        dizi_image(10) = resim11.Image
        dizi_image(11) = resim12.Image
        dizi_image(12) = resim13.Image
        dizi_image(13) = resim14.Image
        dizi_image(14) = resim15.Image
        dizi_image(15) = resim16.Image
        dizi_image(16) = resim17.Image
        dizi_image(17) = resim18.Image
    End Sub

    Private Function rastgele(ByVal elemanlar() As Integer, ByVal eleman�_al As Integer) As Integer()
        'g�nderilen dizi ve comboboxtan se�ilen elemana g�re 
        'gelen elemana uygun olacak say�da kar���k dizi olu�turuluyor
        'ama� bu eleman de�erlerine g�re resimler yerle�tirilecek

        Dim i, j As Integer
        Dim ciz As Integer = eleman�_al / 2
        Dim kac As Integer
        kac = (eleman�_al * ciz)
        For i = 0 To kac - 1
            elemanlar(i) = Rnd() * (kac - 1)
            For j = 0 To i - 1
                If elemanlar(i) = elemanlar(j) Then
                    elemanlar(i) = Rnd() * (kac - 1)
                    j = -1
                End If
            Next
        Next
        Return elemanlar
    End Function

    Private Sub yerlestir(ByVal eleman�_al As Integer)
        'resimler kar��an dizi sayesinde butonlara yerle�tiriliyor
        Dim dizi1(eleman�_al * 3) As Integer
        Dim dizi2(eleman�_al * 3) As Integer
        dizi1 = rastgele(dizi1, eleman�_al)
        System.Threading.Thread.Sleep(500) '�retilen say�lar farkl� olsun diye
        dizi2 = rastgele(dizi2, eleman�_al)

        Dim i, j As Integer
        Dim x As Integer = 0
        Dim y As Integer = 0

        For i = 0 To eleman�_al - 1
            For j = 0 To eleman�_al - 1
                If j Mod 2 = 0 Then
                    dizi_butonlar(i, j).Text = dizi1(x).ToString()
                    x += 1
                Else
                    dizi_butonlar(i, j).Text = dizi2(y).ToString()
                    y += 1
                End If

            Next
        Next

    End Sub

    Private Sub gizle(ByVal eleman�_al As Integer)
        'burda ise kullan�lmayacak olan elemanlar gizleniyor
        Dim i, j As Integer
        For i = 0 To 5
            For j = eleman�_al To 5
                dizi_butonlar(i, j).Visible = False
                dizi_butonlar(j, i).Visible = False
            Next
        Next
    End Sub

    Private Sub goster()
        'b�t�n elemanlar�n g�r�n�rl���n� �nce a�
        Dim i, j As Integer
        For i = 0 To 5
            For j = 0 To 5
                dizi_butonlar(i, j).Visible = True
            Next
        Next
    End Sub

    Private Sub denetle()

        'her do�ru sonu� yap�ld���nda bu prosed�r �al��t�r�l�yor
        'b�ylece t�m resimler a��ksa oyun bitmi� olur 
        Dim kac_eleman As Integer = kac_resimle_oyna
        '�uan kullan�mda olan ka� eleman var diye bak�l�yor
        Dim sayac As Integer = 0
        Dim i, j As Integer

        For i = 0 To 5
            For j = 0 To 5
                'e�er buton g�r�n�rse
                If dizi_butonlar(i, j).Visible = True Then
                    'e�er butonun image i bo� de�ilse
                    If Not (dizi_butonlar(i, j).Image Is bos_image) Then
                        'her turda sayac� bir art�rarak ka� kere bo�olmayan imageli
                        'buton buldumuzu tutuyor..
                        sayac += 1
                        'sayac e�er eleman say�s�na e�itse bitiricez
                        'eleman say�s� da combobox �n textinde yazan ifadenin
                        'karesine e�ittir..
                        If (sayac = kac_eleman * kac_eleman) Then
                            'zaman� durdur
                            timer1.Enabled = False
                            MessageBox.Show("oyun bitti")
                        End If
                        'di�er elemanlara bak�lmas� i�in d�ng�n�n ba��na d�n
                        Continue For
                    Else
                        'e�er bo� olan bitane bile varsa burdan ��k...
                        Exit Sub
                    End If
                End If
            Next
        Next

    End Sub

#End Region

#Region "eventler"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bos_image = ARKA_PLAN.Image
        butonlar()
        resimler()
        gizle(0) 'ilk a��l��ta hepsini gizle

        Me.Width = 245
        Me.Height = 340
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub


    Private Sub oyunba�latToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oyunba�latToolStripMenuItem.Click
        'oyun her ba�lat�ld���nda butonlar�n imagelerini bo�alt
        Dim i, j As Integer
        For i = 0 To 5
            For j = 0 To 5
                dizi_butonlar(i, j).Image = bos_image
                'butonlar�n textindeki yaz�y� k���lt�yorum ��nk�
                'kontrollerimi text �zelli�ine g�re yap�yorum dolay�s�yla g�z�kmesini istemiyorum
                dizi_butonlar(i, j).Font = New Font("arial", 1, FontStyle.Regular)

                'oyun ikinciye veya daha fazla �al��t�rl�yorsa daha �nceden enabled false
                'yap�lm�� elemanlar� tekrar kullan�l�r yapmam�z gerekir..
                'bu y�zden b�t�n elemanlar�n enabled �zelli�ini true yap�yoruz..
                dizi_butonlar(i, j).Enabled = True
            Next
        Next
        yerlestir(kac_resimle_oyna)
        goster()
        gizle(kac_resimle_oyna)
        eleman�_al = kac_resimle_oyna
        'zaman� tutaca��m�z timeri a� ve 1 sn de bir �al��mas�n� sa�la
        zaman = 0
        timer1.Interval = 1000
        timer1.Enabled = True
    End Sub

    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click, b10.Click, b11.Click, b12.Click, b13.Click, b14.Click, b15.Click, b16.Click, b17.Click, b18.Click, b19.Click, b20.Click, b21.Click, b2.Click, b22.Click, b23.Click, b24.Click, b25.Click, b26.Click, b27.Click, b28.Click, b29.Click, b3.Click, b30.Click, b31.Click, b32.Click, b33.Click, b34.Click, b35.Click, b36.Click, b4.Click, b5.Click, b6.Click, b7.Click, b8.Click, b9.Click
        'di�er butonlar�n click lerini de buraya ba�lad�m
        'bunu yapabilmek i�in b�t�n butonlar se�iliyken properties
        'penceresindeki �im�ek i�aretli butona t�klamak ve click eventi i�in
        'b1_Click se�imi yap�lmal�d�r...
        Dim i, j As Integer
        If (tut = "") Then
            'daha �nce se�im yap�lmad�ysa
            For i = 0 To eleman�_al - 1
                For j = 0 To eleman�_al - 1
                    If (sender Is dizi_butonlar(i, j)) Then
                        'g�nderen eleman�n imageni g�stermek i�in a�
                        dizi_butonlar(i, j).Image = dizi_image(Convert.ToInt32(dizi_butonlar(i, j).Text))
                        tut = dizi_butonlar(i, j).Text
                        'bir sonraki bas��ta kullan�lmak �zere deger1 ve deger2
                        'de�i�kenlerine matrisin indis numaralar�n� al
                        deger1 = i
                        deger2 = j
                    End If
                Next
            Next

        Else
            'tut de�i�keninde eleman varsa ikinci elemanla k�yasla
            For i = 0 To eleman�_al - 1
                For j = 0 To eleman�_al - 1
                    If (sender Is dizi_butonlar(i, j)) Then
                        dizi_butonlar(i, j).Image = dizi_image(Convert.ToInt32(dizi_butonlar(i, j).Text))
                        'ekran� refresh lemezsek kod sat�r� bitene kadar yukar�daki kod
                        '�al��m�yor daha do�rusu g�sterilmiyor bunun i�in alttaki
                        'komutu kullanarak ekran� refresh liyoruz..
                        Me.Refresh()
                        System.Threading.Thread.Sleep(1000)

                        If (tut = dizi_butonlar(i, j).Text) Then

                            dizi_butonlar(deger1, deger2).Image = dizi_image(Convert.ToInt32(dizi_butonlar(deger1, deger2).Text))
                            'a��lan elemanlar bir daha a��lmaya �al���lmas�n diye enabled lar� false yap�l�yor...
                            dizi_butonlar(deger1, deger2).Enabled = False
                            dizi_butonlar(i, j).Enabled = False
                            'yeni bir eleman daha a��ld��� i�in elemanlar�n
                            'hepsi bitti mi diye denetle prosed�r�n� �al��t�r..
                            denetle()

                        Else

                            'e�er arka arkaya se�ilen resimler e�it deilse
                            'iki buton un image ini de bo�alt
                            dizi_butonlar(i, j).Image = bos_image
                            dizi_butonlar(deger1, deger2).Image = bos_image
                            'ikinci se�im yap�ld���ndan tut de�i�kenini bo�alt ve yeni se�im yap�lmas�n� sa�la
                        End If
                        tut = ""
                    End If
                Next
            Next
        End If
    End Sub


    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        'timer 1 saniyede bir �al��t��� i�in yani interval � 1000 oldu�u i�in
        'zaman saniye cinsinden tutuluyor g�stermek istedi�imiz zaman ise dakika ile
        'saniye oldu�u i�in zaman de�i�keninden 60 a b�l�m� dakikay�
        'zaman de�i�keninin mod 60 a g�re de�eri ise saniyeyi vermi� olur
        zaman += 1
        Dim dk As Integer = Math.Floor(Convert.ToDouble(zaman / 60))
        Dim sn As Integer = Math.Floor(Convert.ToDouble(zaman Mod 60))
        'dakika ile saniye aras�na nokta koyarak ifade ediyoruz..
        label2.Text = dk.ToString() + "." + sn.ToString() + "  dk."
    End Sub

    Private Sub resimbulToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resimbulToolStripMenuItem.Click
        'resimlerin say�s�na g�re formun boyutlar� ayarlan�yor
        kac_resimle_oyna = 2
        Me.Width = 245
        Me.Height = 340
        '245,340
    End Sub

    Private Sub resimbulToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resimbulToolStripMenuItem1.Click
        kac_resimle_oyna = 4
        Me.Width = 395
        Me.Height = 595
        '395,595
    End Sub

    Private Sub resimbulToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resimbulToolStripMenuItem2.Click
        kac_resimle_oyna = 6
        Me.Width = 870
        Me.Height = 595
        '870,595
    End Sub
#End Region

End Class
