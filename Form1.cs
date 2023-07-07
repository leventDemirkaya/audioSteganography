using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO; // Ses Dosyasından Okuma İşleminde Kullanılmaktadır.
using NAudio.Wave; // Wav Dosyasından Okuma İşleminde Kullanılmaktadır.

namespace SesVerileriÜzerineVeriGizleme
{
    public partial class Form1 : Form
    {
        List<decimal> fibonacciNumbers = new List<decimal>(); // daha fazla karakter gizleyebilmek için veri tipi decimal seçildi.
        List<string> sifirlar = new List<string> { "", "0", "00", "000", "0000", "00000", "000000", "0000000", "00000000" }; // ASCII koduna göre 8 bite tamamlanacak.
        List<string> path = new List<string>(); // Eklenen ses dosyalarının adresi bulunmaktadır
        List<string> sesDosyasiIkiTabani = new List<string>(); //sesDosyasındaki verinin binary değerleri bulunmaktadır
        List<string> saklanacakMesajIkiTabani = new List<string>(); //gizlenecek metinin karakterlerinin binary karşılıkları bulunmaktadır
        List<int> kullanilanIndisler = new List<int>(); // sırasıyla gizleme yapılan bitlerin bulunduğu indisler
        byte[] sesDosyasiOnTabani = null; // gizlenmiş mesajı içeren .wav formatına çevrilmede kullanılacak değişken
        int calistirilmaSayisi = 0; // kaç kez forms'un çalıştığının takibi için kullanılacaktır.
        public Form1()
        {
            InitializeComponent();
            FibonacciOlustur();
        }
        private void bt_SesDosyasiEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
                if (!lstbx_SesDosyalari.Items.Contains(openFileDialog1.SafeFileNames[i].ToString())) // Eğer Listbox'ta seçilen sesDosyası mevcut değilse ekleyecek
                {
                    lstbx_SesDosyalari.Items.Add(openFileDialog1.SafeFileNames[i].ToString()); // SafeFileNames ile sadece dosyaAdı gelmekte, adresi gelmemektedir.
                    path.Add(openFileDialog1.FileNames[i].ToString()); // sesDosyasının adresini de FileNames metodu ile path listesine ekle
                }
        }
        private void lstbx_SesDosyalari_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_GizlenecekMetin.Visible = true; txt_GizlenecekMetin.Visible = true; txt_GizlenecekMetin.Enabled = true;
                bt_MesajGizle.Visible = true; bt_MesajGizle.Enabled = true;
                sesOynatici.URL = path[lstbx_SesDosyalari.SelectedIndex]; // listbox'tan seçilen indeksteki sesDosyasının adresi sesOynatıcıya gönderilir.
                sesOynatici.Ctlcontrols.play();
                byte[] sesDosyasi = File.ReadAllBytes(path[lstbx_SesDosyalari.SelectedIndex]); // sesDosyasının decimal tabanına dönüşümü sağlanır
                IkiTabaninaCevir(sesDosyasi, 1); // Gizleme işlemi için 8 bit uzunluğunda binary tabanında sayıya dönüştürülür.
            }
            catch(Exception) // listbox içerisinde geçersiz bir alana tıklayınca oluşan exception'ı kontrol etmek için.
            {
                MessageBox.Show("Listeden seçim sırasında hata oluştu, tekrar deneyiniz");
                lbl_GizlenecekMetin.Visible = false; txt_GizlenecekMetin.Visible = false; txt_GizlenecekMetin.Enabled = false;
                bt_MesajGizle.Visible = false; bt_MesajGizle.Enabled = false; // gizleme yapılacak orijinal dosya doğru seçilmezse gizlenecekMetin özellikleri görünür olmayacak.
            }
        }
        private void IkiTabaninaCevir(byte[] dizi, byte dosyaTipi)
        {
            StreamWriter sw = null;
            int sayac = 0;
            if (dosyaTipi == 1) // orijinalDosya indisi 1 olarak belirlendi.
            {
                sw = new StreamWriter(@"orijinalDosya.txt"); // orijinal ses verilerinin binary formdaki karşılıkları bu .txt uzantısında bulunacak
                for (int i = 0; i < dizi.Length; i++)
                {
                    string temp = Convert.ToString(dizi[i], 2); // decimalden binary'e dönüşüm
                    if (temp.Length < 8) // 8 bitten kısa ise 8 bite ulaşması için sifirlar listesinden ekleme olacak
                        temp = sifirlar[8 - temp.Length] + temp;
                    sw.WriteLine(((++sayac) + ". eleman ---> " + dizi[i] + " : \t" + temp)); // 8 bite ulaşan sesVerisi txt dosyasına yazıldı.
                    sesDosyasiIkiTabani.Add(temp); // sonuç listesi kullanılarak veriGizleme yapılacaktır.
                }
                MessageBox.Show("Orijinal Ses Dosyası Binary Tabana Dönüştürülüp .txt Formatında Yazılmıştır.","İşlem Başarılı");
            }
            else if (dosyaTipi == 2)
            {
                sw = File.AppendText(@"gizlenmisMesaj.txt"); // gizlenmişMesaj.txt oluşturulup 8 bit binary formdaki gizlenmiş mesaj değerleri tutulacak.
                String mesaj = txt_GizlenecekMetin.Text;
                sw.Write($"Gizlenecek Mesaj: {mesaj}\nBinary Olarak Kodlanmış Hali :\n");
                for (int i = 0; i < mesaj.Length; i++)
                {
                    string temp = Convert.ToString(mesaj[i], 2); // dosyaTipi=1 parametresine göre tek değişiklik, dizi[i] değil de mesaj[i] parametre alınıyor.
                    if (temp.Length < 8) // 8 bitten kısa ise 8 bite ulaşması için sifirlar listesinden ekleme olacak
                        temp = sifirlar[8 - temp.Length] + temp;
                    saklanacakMesajIkiTabani.Add(temp);
                    sw.WriteLine(((++sayac) + ". eleman ---> " + mesaj[i] + " : " + temp));
                }
                sw.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                MessageBox.Show("Gizlenecek mesaj dosyaya yazılmıştır.","İşlem Başarılı");
            }
            sw.Close();
        }
        private void OnTabaninaCevir()
        {
            sesDosyasiOnTabani = new byte[sesDosyasiIkiTabani.Count];
            for(int i=0;i<sesDosyasiIkiTabani.Count;i++) 
            {
                string temp = ""; byte deger = 0; // iki tabanındaki dosyada değişiklik yapmamak için temp değişkeni tanımlandı
                for(int j=sesDosyasiIkiTabani[i].Length-1;j>=0;j--) // taban dönüşümü yapmak için string tersten yazıldı
                    temp += sesDosyasiIkiTabani[i][j];
                for(int j=0;j<temp.Length;j++) 
                {
                    if(temp[j]=='1') // 1 değerine sahipse binary --> decimal dönüşümü 2^j(i'nin basamak sayısı) olarak yapılacak.         
                        deger += (byte)(Math.Pow(2, j));                    
                }
                sesDosyasiOnTabani[i] = deger;
            }
        }
        private void bt_MesajGizle_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"degistirilmisDosya.txt"); ;
            if (txt_GizlenecekMetin.Text != "") // Gizlenecek metin girilmişse çalışacak
            {
                byte kontrol = 0; // Türkçe Karakter kullanılmasının kontrolünde kullanılmaktadır.
                for (byte i = 0; i < txt_GizlenecekMetin.Text.Length; i++)
                    if (txt_GizlenecekMetin.Text.ToLower()[i] == 'ğ' || txt_GizlenecekMetin.Text.ToLower()[i] == 'ü' || 
                        txt_GizlenecekMetin.Text.ToLower()[i] == 'ç' || txt_GizlenecekMetin.Text[i] == 'ı' || 
                        txt_GizlenecekMetin.Text.ToLower()[i] == 'ö' || txt_GizlenecekMetin.Text[i]=='İ')
                    {
                        kontrol = 1;
                        break;
                    }
                if (kontrol == 0) // Türkçe karakter kullanılmamışsa iki tabanına çevrilecek.
                {
                    IkiTabaninaCevir(null, 2); // eğer boş metin değilse çalışacak
                    txt_GizlenecekMetin.Enabled = false;
                    bt_MesajGizle.Enabled = false;
                }
                else MessageBox.Show("Türkçe Karakter Kullanılmaması Gereklidir.", "HATA ");
            }
            else MessageBox.Show("Gizlenecek metin girilmedi, tekrar deneyiniz.", "HATA !");
            if (saklanacakMesajIkiTabani.Count != 0) // Gizlenecek metin girilmiş ve 2 tabanına çevrimi sağlanmışsa
            {
                LSBGizlemeYap(sw);
                OnTabaninaCevir();
                WavDosyasiOlustur();
                Zamanlayici.Start();
                DegiskenTemizle();
            }
            sw.Close();
        }
        private void FibonacciOlustur()
        {
            fibonacciNumbers.Add(0); fibonacciNumbers.Add(1); fibonacciNumbers.Add(2);
            for (int i = 2; i < 136; i++) // 17 karaktere kadar gizleme yapabilecektir. [decimal max.value aşılıyor]
                fibonacciNumbers.Add(fibonacciNumbers[i] + fibonacciNumbers[i - 1]);
        }
        private void LSBGizlemeYap(StreamWriter sw)
        {
            int fiboIndis = 0, gizlenmisIndis = 0; // fiboIndis kaç karaktere kadar indexOutOfRange hatası yenmeden çalışacağını tutmakta, gizlenmiş indiste ise kaçıncı 8 bitlik karakterde olunduğunun bilgisi tutulmaktadır.
            String tempOrijinal, tempGizlenmisMesaj = saklanacakMesajIkiTabani[gizlenmisIndis++]; // tempOrijinal, orijinal ses dosyasında ; tempGizlenmişMesaj ise gizlenecek metin üzerindeki bit işlemlerinde kullanılacaktır.
            for (int i = 0; fibonacciNumbers[i] < sesDosyasiIkiTabani.Count; i++)
                fiboIndis++; // orijinal ses dosyasında, fibonacci serisi kullanılarak ulaşılabilecek en son bitin indisi tutulmaktadır.
            for (int i = 0; i < saklanacakMesajIkiTabani.Count*8; i++) // bit bazlı işlem yapıldığı için 8 bite dönüştürülen gizlenecekMesaj kadar dönecektir.
            {
                decimal tutulanFiboDegeri = fibonacciNumbers[i];
                if (i>=fiboIndis) // fibonacci sınırları orijinal mesaj için outOfRange hatası veriyorsa, düzenleme yapılması gerekli.
                    tutulanFiboDegeri = (fibonacciNumbers[i] % sesDosyasiIkiTabani.Count);
                int tempSayac = i % 8;  // i sayacını döngü değişkeni olduğu için güncellenemez, o yüzden tempSayac oluşturuldu.
                tempOrijinal = sesDosyasiIkiTabani[(int)tutulanFiboDegeri];   // Fibonacci sayısına denk gelen orijinal 8-bitlik dizginin LSB haricindeki dizgisi alınacak.
                if (i % 8 == 0 && i > 0)    // gizlenecekMesajın ilgili karakterinin bütün bitleri gizlenip sıradaki karaktere geçilecekse
                    tempGizlenmisMesaj = saklanacakMesajIkiTabani[gizlenmisIndis++];    // gizlenmişIndis değeri arttırılarak sıradaki 8 bit tempGizlenmişMesaj içerisine yazılır.
                char tempKarakter = tempGizlenmisMesaj[tempSayac];  // Karşılaştırılacak ve uyumsuz olursa değiştirilecek bit değeridir. tempSayac indis olarak alındı, çünkü i%8'den dolayı 0 değerinden başlıyor.
                if (tempOrijinal[tempOrijinal.Length - 1] != tempKarakter)  // eğer orijinal LSB ile tempKarakter farklıysa, LSB değiştirilecek
                {
                    tempOrijinal = tempOrijinal.Substring(0, tempOrijinal.Length - 1);  // orijinalMesajın sadece LSB'si değişeceği için ilk 7 biti korundu.
                    tempOrijinal += tempKarakter;    // gizlenecekKarakter orijinal mesaja ekleniyor.
                    sesDosyasiIkiTabani[(int)tutulanFiboDegeri] = tempOrijinal;   // Listedeki indisteki değer de güncelleniyor.
                } // else yazılmasına gerek olmuyor, değiştirilme olmadığı için orijinal mesajın indisinin tutulması yeterli oluyor.     
                sw.WriteLine((i + 1) + ".karakter " + tutulanFiboDegeri + ". elemana gizlenmiş olup 8 bit ASCII karşılığı : " + tempOrijinal);
                kullanilanIndisler.Add((int)tutulanFiboDegeri);
            }
        } 
        private void txt_GizlenecekMetin_MouseClick(object sender, MouseEventArgs e)
        {
            txt_GizlenecekMetin.Clear(); // Gizlenebilecek karakter üst limiti mesajı kullanıcı tarafından okunduktan sonra silinmesi sağlanacaktır.
        }
        private String GizlenenMesajiGoster()
        {
            string sonuc = "",tempTersten="",tempNormal=""; 
            char karakter; byte deger = 0, limit = 8;
            for(int i=1;i<=kullanilanIndisler.Count;i++)
            {
                karakter = sesDosyasiIkiTabani[kullanilanIndisler[i-1]][sesDosyasiIkiTabani[kullanilanIndisler[i-1]].Length-1];
                tempTersten += karakter;
                if(i%limit==0)
                {
                    for(int j=tempTersten.Length-1;j>=0;j--)
                        tempNormal += tempTersten[j];
                    for(int j=0;j<tempNormal.Length;j++)
                    {
                        if(tempNormal[j]=='1')
                            deger += (byte)Math.Pow(2, j);
                    }
                    sonuc += (char)deger;
                    tempTersten = ""; tempNormal = ""; deger = 0;
                }
            }
            return sonuc;
        }
        private void WavDosyasiOlustur()
        {
            String dosyaAdi = $"gizlenen{++calistirilmaSayisi}.wav";
            File.WriteAllBytes(dosyaAdi, sesDosyasiOnTabani);
            txt_GizlenenMesaj.Text = GizlenenMesajiGoster();
            lbl_GizlenenMesaj.Visible = true; txt_GizlenenMesaj.Visible = true;
            sesOynatici.URL = path[lstbx_SesDosyalari.SelectedIndex];
            if (DosyaGecerliMi(@dosyaAdi))
            {
                txt_GizlenenMesaj.Location = new Point(192,598);
                lbl_GizlenenMesaj.Location = new Point(9,601);
                this.Size = new Size(805, 679);
                gizlenmisMesajOynatici.Visible = true;
                gizlenmisMesajOynatici.URL = dosyaAdi;
                gizlenmisMesajOynatici.Ctlcontrols.play();
            }
            else
            {
                txt_GizlenenMesaj.Location = new Point(192,356);
                lbl_GizlenenMesaj.Location = new Point(12,359);
                this.Size = new Size(800,438);
            }
            sesOynatici.Ctlcontrols.play();
        }
        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool DosyaGecerliMi(string adres)
        {
            try
            {
                using (var oku = new WaveFileReader(adres)) // Dosya başarıyla okunabiliyorsa true return ediyoruz
                    return true;
            }
            catch (Exception) // Dosya okunamadı veya hata oluştuysa false return ediyoruz
            {
                return false;
            }
        }
        private void DegiskenTemizle()
        {
            // İlk çalıştırmadan sonra yeni değerlerin işlenebilmesi için temizlenmesi gereklidir.
            sesDosyasiIkiTabani.Clear();
            saklanacakMesajIkiTabani.Clear();
            kullanilanIndisler.Clear();
            sesDosyasiOnTabani = null;
        }
    }
}