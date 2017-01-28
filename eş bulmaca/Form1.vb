Public Class Form1
    'Korh@N GeRiÞ prestige 2005 

    'resimler önce pictureboxlara sonra da diziye alýnarak kullanýlýyor..
    'default 2 resim için form açýlýyor sonradan menustrip ile deðiþtirilebiliyor

#Region "global deðiþkenler"
    'týklanan son elemaný tut
    Dim tut As String = ""
    ' elemaný boþaltmak için tanýmladým
    Dim bos_image As Image
    'b1_click te sender ile kimin bastýðýný anlýyoruz
    Dim elemaný_al As Integer
    Dim deger1, deger2 As Integer
    Dim zaman As Integer = 0
    Dim dizi_image(17) As Image
    Dim dizi_butonlar(5, 5) As Button
    Dim kac_resimle_oyna As Integer = 2

#End Region

#Region "prosedürler"

    Private Sub butonlar()
        'butonlar diziye alýndý
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
        'pictureboxlarda ki resimler image dizisine aktarýlýyor
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

    Private Function rastgele(ByVal elemanlar() As Integer, ByVal elemaný_al As Integer) As Integer()
        'gönderilen dizi ve comboboxtan seçilen elemana göre 
        'gelen elemana uygun olacak sayýda karýþýk dizi oluþturuluyor
        'amaç bu eleman deðerlerine göre resimler yerleþtirilecek

        Dim i, j As Integer
        Dim ciz As Integer = elemaný_al / 2
        Dim kac As Integer
        kac = (elemaný_al * ciz)
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

    Private Sub yerlestir(ByVal elemaný_al As Integer)
        'resimler karýþan dizi sayesinde butonlara yerleþtiriliyor
        Dim dizi1(elemaný_al * 3) As Integer
        Dim dizi2(elemaný_al * 3) As Integer
        dizi1 = rastgele(dizi1, elemaný_al)
        System.Threading.Thread.Sleep(500) 'üretilen sayýlar farklý olsun diye
        dizi2 = rastgele(dizi2, elemaný_al)

        Dim i, j As Integer
        Dim x As Integer = 0
        Dim y As Integer = 0

        For i = 0 To elemaný_al - 1
            For j = 0 To elemaný_al - 1
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

    Private Sub gizle(ByVal elemaný_al As Integer)
        'burda ise kullanýlmayacak olan elemanlar gizleniyor
        Dim i, j As Integer
        For i = 0 To 5
            For j = elemaný_al To 5
                dizi_butonlar(i, j).Visible = False
                dizi_butonlar(j, i).Visible = False
            Next
        Next
    End Sub

    Private Sub goster()
        'bütün elemanlarýn görünürlüðünü önce aç
        Dim i, j As Integer
        For i = 0 To 5
            For j = 0 To 5
                dizi_butonlar(i, j).Visible = True
            Next
        Next
    End Sub

    Private Sub denetle()

        'her doðru sonuç yapýldýðýnda bu prosedür çalýþtýrýlýyor
        'böylece tüm resimler açýksa oyun bitmiþ olur 
        Dim kac_eleman As Integer = kac_resimle_oyna
        'þuan kullanýmda olan kaç eleman var diye bakýlýyor
        Dim sayac As Integer = 0
        Dim i, j As Integer

        For i = 0 To 5
            For j = 0 To 5
                'eðer buton görünürse
                If dizi_butonlar(i, j).Visible = True Then
                    'eðer butonun image i boþ deðilse
                    If Not (dizi_butonlar(i, j).Image Is bos_image) Then
                        'her turda sayacý bir artýrarak kaç kere boþolmayan imageli
                        'buton buldumuzu tutuyor..
                        sayac += 1
                        'sayac eðer eleman sayýsýna eþitse bitiricez
                        'eleman sayýsý da combobox ýn textinde yazan ifadenin
                        'karesine eþittir..
                        If (sayac = kac_eleman * kac_eleman) Then
                            'zamaný durdur
                            timer1.Enabled = False
                            MessageBox.Show("oyun bitti")
                        End If
                        'diðer elemanlara bakýlmasý için döngünün baþýna dön
                        Continue For
                    Else
                        'eðer boþ olan bitane bile varsa burdan çýk...
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
        gizle(0) 'ilk açýlýþta hepsini gizle

        Me.Width = 245
        Me.Height = 340
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub


    Private Sub oyunbaþlatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oyunbaþlatToolStripMenuItem.Click
        'oyun her baþlatýldýðýnda butonlarýn imagelerini boþalt
        Dim i, j As Integer
        For i = 0 To 5
            For j = 0 To 5
                dizi_butonlar(i, j).Image = bos_image
                'butonlarýn textindeki yazýyý küçültüyorum çünkü
                'kontrollerimi text özelliðine göre yapýyorum dolayýsýyla gözükmesini istemiyorum
                dizi_butonlar(i, j).Font = New Font("arial", 1, FontStyle.Regular)

                'oyun ikinciye veya daha fazla çalýþtýrlýyorsa daha önceden enabled false
                'yapýlmýþ elemanlarý tekrar kullanýlýr yapmamýz gerekir..
                'bu yüzden bütün elemanlarýn enabled özelliðini true yapýyoruz..
                dizi_butonlar(i, j).Enabled = True
            Next
        Next
        yerlestir(kac_resimle_oyna)
        goster()
        gizle(kac_resimle_oyna)
        elemaný_al = kac_resimle_oyna
        'zamaný tutacaðýmýz timeri aç ve 1 sn de bir çalýþmasýný saðla
        zaman = 0
        timer1.Interval = 1000
        timer1.Enabled = True
    End Sub

    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click, b10.Click, b11.Click, b12.Click, b13.Click, b14.Click, b15.Click, b16.Click, b17.Click, b18.Click, b19.Click, b20.Click, b21.Click, b2.Click, b22.Click, b23.Click, b24.Click, b25.Click, b26.Click, b27.Click, b28.Click, b29.Click, b3.Click, b30.Click, b31.Click, b32.Click, b33.Click, b34.Click, b35.Click, b36.Click, b4.Click, b5.Click, b6.Click, b7.Click, b8.Click, b9.Click
        'diðer butonlarýn click lerini de buraya baðladým
        'bunu yapabilmek için bütün butonlar seçiliyken properties
        'penceresindeki þimþek iþaretli butona týklamak ve click eventi için
        'b1_Click seçimi yapýlmalýdýr...
        Dim i, j As Integer
        If (tut = "") Then
            'daha önce seçim yapýlmadýysa
            For i = 0 To elemaný_al - 1
                For j = 0 To elemaný_al - 1
                    If (sender Is dizi_butonlar(i, j)) Then
                        'gönderen elemanýn imageni göstermek için aç
                        dizi_butonlar(i, j).Image = dizi_image(Convert.ToInt32(dizi_butonlar(i, j).Text))
                        tut = dizi_butonlar(i, j).Text
                        'bir sonraki basýþta kullanýlmak üzere deger1 ve deger2
                        'deðiþkenlerine matrisin indis numaralarýný al
                        deger1 = i
                        deger2 = j
                    End If
                Next
            Next

        Else
            'tut deðiþkeninde eleman varsa ikinci elemanla kýyasla
            For i = 0 To elemaný_al - 1
                For j = 0 To elemaný_al - 1
                    If (sender Is dizi_butonlar(i, j)) Then
                        dizi_butonlar(i, j).Image = dizi_image(Convert.ToInt32(dizi_butonlar(i, j).Text))
                        'ekraný refresh lemezsek kod satýrý bitene kadar yukarýdaki kod
                        'çalýþmýyor daha doðrusu gösterilmiyor bunun için alttaki
                        'komutu kullanarak ekraný refresh liyoruz..
                        Me.Refresh()
                        System.Threading.Thread.Sleep(1000)

                        If (tut = dizi_butonlar(i, j).Text) Then

                            dizi_butonlar(deger1, deger2).Image = dizi_image(Convert.ToInt32(dizi_butonlar(deger1, deger2).Text))
                            'açýlan elemanlar bir daha açýlmaya çalýþýlmasýn diye enabled larý false yapýlýyor...
                            dizi_butonlar(deger1, deger2).Enabled = False
                            dizi_butonlar(i, j).Enabled = False
                            'yeni bir eleman daha açýldýðý için elemanlarýn
                            'hepsi bitti mi diye denetle prosedürünü çalýþtýr..
                            denetle()

                        Else

                            'eðer arka arkaya seçilen resimler eþit deilse
                            'iki buton un image ini de boþalt
                            dizi_butonlar(i, j).Image = bos_image
                            dizi_butonlar(deger1, deger2).Image = bos_image
                            'ikinci seçim yapýldýðýndan tut deðiþkenini boþalt ve yeni seçim yapýlmasýný saðla
                        End If
                        tut = ""
                    End If
                Next
            Next
        End If
    End Sub


    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        'timer 1 saniyede bir çalýþtýðý için yani interval ý 1000 olduðu için
        'zaman saniye cinsinden tutuluyor göstermek istediðimiz zaman ise dakika ile
        'saniye olduðu için zaman deðiþkeninden 60 a bölümü dakikayý
        'zaman deðiþkeninin mod 60 a göre deðeri ise saniyeyi vermiþ olur
        zaman += 1
        Dim dk As Integer = Math.Floor(Convert.ToDouble(zaman / 60))
        Dim sn As Integer = Math.Floor(Convert.ToDouble(zaman Mod 60))
        'dakika ile saniye arasýna nokta koyarak ifade ediyoruz..
        label2.Text = dk.ToString() + "." + sn.ToString() + "  dk."
    End Sub

    Private Sub resimbulToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resimbulToolStripMenuItem.Click
        'resimlerin sayýsýna göre formun boyutlarý ayarlanýyor
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
