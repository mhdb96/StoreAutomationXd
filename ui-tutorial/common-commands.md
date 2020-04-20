---
description: >-
  Menülerin her birinde “Add”, ”Update”, ”Delete”, “Search” ve “Filter”
  kısımları bulunmaktadır. Bu kısımlar için her menüye özel Sql kodları
  yazılmıştır.
---

# Common Commands

## **Add**

 “Add” butonuna tıklandığında açılan pencerede istenilen değerleri girerek  veri tabanına veri eklenebilmektedir.

## **Update**

“Update” butonuna tıklandığında açılan pencerede seçilen kullanıcıların bilgileri input kısımlarına otomatik olarak yerleştirilmiştir. Düzeltilmek istenen değerler düzeltildiğinde veri tabanında ki veriler güncellenecektir.

## **Delete**

“Delete” butonuna bir veri seçilip tıklandığında eğer o verinin başka bir tabloda ForeignKey’i yoksa hemen silinecektir. Eğer seçilen verinin başka bir tabloda ForeignKey’i varsa kullanıcının karşısına bir uyarı mesajı çıkacaktır

## **Search**

“Search” butonuna tıklandığında “Search” butonunun yanında bulunan TextBox’a girilen değeri veri tabanında aratıp çıkan değerleri Grid’de gösterir.

## **Filter**

Grid kısmında gösterilecek veriyi istenilen kategorilere göre sınırlandırmak için kullanılır ve ayrıca bu kısım Admin Paneli kısmında fazla işe yaramayacağı için sadece Veri Girişi Paneli kısmında bulunmaktadır.

