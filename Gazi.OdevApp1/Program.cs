using System.ComponentModel.Design;

namespace Gazi.OdevApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    Console.Write("Kaç tane öğrenci kaydetmek istiyorsunuz: ");
                    int ogrenciSayisi = int.Parse(Console.ReadLine());
                    string[,] dizi = new string[ogrenciSayisi + 1, 7];
                    double toplam = 0;
                    double max = double.MinValue;
                    double min = double.MaxValue;

                    for (int i = 1; i <= ogrenciSayisi; i++)
                    {
                        string no;
                        do
                        {
                            Console.Write($"{i}. Öğrenci numarası giriniz: ");
                            no = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(no))
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Öğrenci numarası boş bırakılamaz.");
                            }
                            else if (no.All(char.IsDigit))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Öğrenci numarası sadece sayılardan oluşmalıdır.");
                            }
                        } while (true);

                        string ad;
                        do
                        {
                            Console.Write($"{i}. Öğrenci adı giriniz : ");
                            ad = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(ad))
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Ad boş bırakılamaz.");
                            }
                            if (!ad.All(char.IsLetter))
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Ad sadece harflerden oluşmalıdır.");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                        string soy;
                        do
                        {
                            Console.Write($"{i}. Soyadı giriniz : ");
                            soy = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(soy))
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Soyad boş bırakılamaz.");
                            }
                            if (!soy.All(char.IsLetter))
                            {
                                Console.WriteLine("Hatalı giriş yaptınız, Soyad sadece harflerden oluşmalıdır.");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                        double vize, final;
                        do
                        {
                            Console.Write($"{i}. Öğrenci Vize notu giriniz (0-100): ");
                            string input = Console.ReadLine();
                            if (double.TryParse(input, out vize) && vize >= 0 && vize <= 100)
                            {
                                break;
                            }
                            Console.WriteLine("Hatalı giriş yaptınız, Vize notu 0 ile 100 arasında bir değer olmalıdır.");
                        } while (true);

                        do
                        {
                            Console.Write($"{i}. Öğrenci Final notu giriniz (0-100): ");
                            string input = Console.ReadLine();
                            if (double.TryParse(input, out final) && final >= 0 && final <= 100)
                            {
                                break;
                            }
                            Console.WriteLine("Hatalı giriş yaptınız, Final notu 0 ile 100 arasında bir değer olmalıdır.");
                        } while (true);

                        double ortalama = vize * 0.4 + final * 0.6;
                        max = Math.Max(max, Math.Max(vize, final));
                        min = Math.Min(min, Math.Min(vize, final));

                        string harfNotu = ortalama >= 85 ? "AA" :
                                         ortalama >= 75 ? "BA" :
                                         ortalama >= 60 ? "BB" :
                                         ortalama >= 50 ? "CB" :
                                         ortalama >= 40 ? "CC" :
                                         ortalama >= 30 ? "DC" :
                                         ortalama >= 20 ? "DD" :
                                         ortalama >= 10 ? "FD" : "FF";

                        dizi[i, 0] = no;
                        dizi[i, 1] = ad;
                        dizi[i, 2] = soy;
                        dizi[i, 3] = vize.ToString();
                        dizi[i, 4] = final.ToString();
                        dizi[i, 5] = ortalama.ToString("0.00");
                        dizi[i, 6] = harfNotu;
                        toplam += ortalama;
                    }

                    dizi[0, 0] = "Öğrenci No";
                    dizi[0, 1] = "Ad";
                    dizi[0, 2] = "Soyad";
                    dizi[0, 3] = "Vize Notu";
                    dizi[0, 4] = "Final Notu";
                    dizi[0, 5] = "Ortalama";
                    dizi[0, 6] = "Harf Notu";

                    Console.WriteLine("\nGirilen Öğrenci Bilgileri:");
                    for (int i = 0; i <= ogrenciSayisi; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            Console.Write($"{dizi[i, j],-15}");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nSınıf Bilgileri:");
                    Console.WriteLine($"Sınıf Ortalaması: {toplam / ogrenciSayisi:0.00}");
                    Console.WriteLine($"En Yüksek Not: {max}");
                    Console.WriteLine($"En Düşük Not: {min}");

                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Girdiğiniz değer çok büyük veya çok küçük. Lütfen tekrar deneyiniz.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Beklenmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");
                }


            }
        }
    }
}
                    

                        








        