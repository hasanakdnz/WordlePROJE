// Gerekli kütüphaneleri ekliyoruz. TextMeshPro için bu satır önemli.
using System.Collections.Generic;
using TMPro; // Bu satırı eklediğinizden emin olun
using UnityEngine;
using UnityEngine.UI; // Button sınıfı için bu gerekli olabilir, eski Unity versiyonları için

public class ContentController : MonoBehaviour
{
    // Unity editöründen atayacağımız nesneler
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button temp; // Bu muhtemelen odak kaybetme için kullanılıyor
    [SerializeField] private List<RowController> rows;
    [SerializeField] private WordManager wordManager;

    // --- YENİ EKLENEN ALANLAR ---
    // "Başardın" mesajını gösterecek metin nesnesi
    [SerializeField] private TextMeshProUGUI basardinYazisi;

    // "Kaybettin" mesajını gösterecek metin nesnesi
    [SerializeField] private TextMeshProUGUI kaybettinYazisi;
    // ----------------------------

    // Hangi tahmin satırında olduğumuzu takip eden değişken
    private int _index;

    private void Start()
    {
        // Oyun başladığında, input alanındaki değişiklikleri ve gönderme işlemini dinlemeye başla
        inputField.onValueChanged.AddListener(OnUpdateContent);
        inputField.onSubmit.AddListener(OnSubmit);
    }

    // Input alanına bir harf yazıldığında veya silindiğinde çalışır
    private void OnUpdateContent(string msg)
    {
        // Mevcut satırdaki hücreleri günceller
        var row = rows[_index];
        row.UpdateText(msg);
    }

    // Harflerin durumunu (doğru, yanlış yer, yok) güncelleyen fonksiyon
    private bool UpdateState()
    {
        // WordManager'dan harflerin durumunu al (Correct, Contain, Fail)
        var states = wordManager.GetStates(inputField.text);
        
        // Mevcut satırın hücre renklerini bu durumlara göre güncelle
        rows[_index].UpdateState(states);

        // Kazanıp kazanmadığını kontrol et
        foreach (var state in states)
        {
            // Eğer bir tane bile "Correct" olmayan harf varsa, kazanmamıştır.
            if (state != State.Correct)
                return false;
        }

        // Döngü bitti ve hepsi "Correct" ise, kazanmıştır.
        return true;
    }

    // Kullanıcı kelimeyi yazıp "Enter" tuşuna bastığında çalışır
    private void OnSubmit(string msg)
    {
        // Input alanının odağını tazelemek için
        temp.Select();
        inputField.Select();

        // Kelime uzunluğu yeterli mi kontrol et
        if (!IsEnough())
        {
            Debug.Log("YETERSIZ... (Kelime çok kısa)");
            return;
        }

        // Harflerin durumunu güncelle ve kazanıp kazanmadığını kontrol et
        var isWin = UpdateState();
        if (isWin)
        {
            // --- KAZANMA DURUMU ---
            // "Başardın" yazısını görünür yap
            basardinYazisi.gameObject.SetActive(true);
            
            // Daha fazla yazı yazılamaması için input alanını devre dışı bırak
            inputField.enabled = false;
            return; // Fonksiyondan çık, daha fazla işlem yapma
        }

        // Kazanmadıysa, bir sonraki tahmin satırına geç
        _index++;
        
        // Kaybedip kaybetmediğini kontrol et (tahmin hakkı bitti mi?)
        var isLost = _index == rows.Count;
        if (isLost)
        {
            // --- KAYBETME DURUMU ---
            // "Kaybettin" yazısını görünür yap
            kaybettinYazisi.gameObject.SetActive(true);

            // Daha fazla yazı yazılamaması için input alanını devre dışı bırak
            inputField.enabled = false;
            return; // Fonksiyondan çık
        }

        // Bir sonraki tur için input alanını temizle
        inputField.text = "";
    }

    // Girilen kelimenin uzunluğunun, satırdaki hücre sayısına eşit olup olmadığını kontrol eder
    private bool IsEnough()
    {
        return inputField.text.Length == rows[_index].CellAmount;
    }
}