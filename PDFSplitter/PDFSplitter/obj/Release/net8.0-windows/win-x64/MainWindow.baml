   M S B A M L   `   `   `  ���� F  BPDFSplitter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PDFSplitterPDFSplitter      PDFSplitter.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:PDFSplitter     -     �Name$  PDF_Splitter�� � Title$ PDF Splitter by PepS��$	��546��$	��900�����	#FF2E2E2E � WindowStyle$ ThreeDBorderWindow=�$	��900��$	��550��$	��547��$	��900��
�������.��� .+��� -    ��Name$ title��$��PDF FILE SPLITTER��$��Center=�$��0,36,0,0q�$	��Top=�$��Center=�$
��Bold"�$��16(����	#FFD0D0D0�� -   $ program_type��$��prototype 2.0��$��Center=�$��0,67,0,0q�$	��Top=�$
��Bold"����	#FFD8D6D6$��31��$��90��$��Center=�$��10(��� -    ��Name$ txtFilePath��$
��Left=�$��197,194,0,0q� �� TextWrapping$ NoWrap=�$��elérési út...��$	��Top=�$	��205��$��26��$��Center=�
������ 
������ ���	#FFD8D8D8.������  �� 
TargetType" ��.���  �� Property � �� �� Value �� 	 �� 
TargetType"	 ��.R�� .+��� 
 ��Name$
 Border��
������ 
������ ._���  ��Name$ PART_ContentHost��$��0q���  ��Name$ 	Underline��$��2�����#39FF14$��Bottom=�$��Stretch=�$y�Visible=� �� Triggers P�  P� Property �@J�IsKeyboardFocused P� Value$
 True��. ���  �� 
TargetName$ 	Underline�� � �� �#02fce7�� $ 	Underline�� � ��$ 2��P�  �@J�IsKeyboardFocused$ False��. ��� $ 	Underline�� � �� �#39FF14�� $ 	Underline�� � ��$ 2��.���� $ ��Darabolásra szánt fájl:��$
��Left=�$��
29,195,0,0q�$	��Top=�
�������$��14(��� -    ��Name$ 	btnBrowse��$��
TALLÓZÁS��$
��Left=�$	��Top=�$	��110��$��45��$��453,187,0,0q����� " ��.���  � �� �#2d6a4f��  � ��
 �������  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z�� �� CornerRadius$ 10��
������ ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#74c69dP�  � ��$
 True��. ���  � �� �#74c69d�� -   $ btnSplit��$��PDF SZÉTVÉLASZTÁS��$
��Left=�$	��Top=�$	��150��$��46��$��676,184,0,0q����� " ��.���  � �� �	#FFB84C4C��  � ��
 �������  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 10��
������ ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#FFCC6666P�  � ��$
 True��. ���  � �� �	#FFE57373�� -   $ processedLabel��$��0/0 oldal feldolgozva��$��Center=�$��	0,472,0,0q�$	��Top=� J� RenderTransformOrigin$ 2.752,0.529&�
�������$��18(�$��	Agency FB)��� -   $ btnSplitbyName��$0��*PDF SZÉTVÉLASZTÁS 
       NÉV SZERINT��$
��Left=�$	��Top=�$	��150��$��45��$��676,255,0,0q�$��Center=����� " ��.���  � �� �	#FFB84C4C��  � ��
 �������  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 10��
������ ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#FFCC6666P�  � ��$
 True��. ���  � �� �	#FFE57373�� $��Fájlok egyesítése:��$
��Left=�$��
29,329,0,0q�$	��Top=�
�������$��14(��� -	    ��Name$ listPdfFiles�� �� DisplayMemberPath$ FileName��$
��Left=�$	��Top=�$��197,295,0,0q�$	��253��$	��108�����	#FF72A79A
�������$��0q�$��	Agency FB)�$��16(����� *
PdfFiles+�� -
   $ btnMergePdf��$��PDF EGYESÍTÉS��$
��Left=�$	��Top=�$	��150��$��46��$��676,326,0,0q�$��Center=����� " ��.���  � �� �#ff7b00��  � ��
 �������  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 10��
������ ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#ffaa00P�  � ��$
 True��. ���  � �� �#ffaa00�� -   $ btnAdd��$��+��$
��Left=�$��480,276,0,0q�$	��Top=�$��	Agency FB)�$
��Bold"�$��16(�$��27��$��28������ " ��.���  � �� �#44AD84��  � ��
 �������  � ��
 ���� ��  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 0��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#61C79FP�  � ��$
 True��. ���  � �� �#399D72�� -   $ 	btnMoveUp��$	��↑��$
��Left=�$��480,353,0,0q�$	��Top=�$��	Agency FB)�$
��Bold"�$��16(�$��27��$��28������ " ��.���  � �� �	#FFDC920D��  � ��
 �������  � ��
 ���� ��  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 0��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#ffaa00P�  � ��$
 True��. ���  � �� �#ffaa00�� -   $ btnMoveDown��$	��↓��$
��Left=�$��480,391,0,0q�$	��Top=�$��	Agency FB)�$
��Bold"�$��16(�$��26��$��28������ " ��.���  � �� �	#FFDC920D��  � ��
 �������  � ��
 ���� ��  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 0��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#ffaa00P�  � ��$
 True��. ���  � �� �#ffaa00�� -   $ 	btnRemove��$��x��$
��Left=�$��480,314,0,0q�$	��Top=�$��	Agency FB)�$
��Bold"�$��16(�$��26��$��28������ " ��.���  � �� �#E63946��  � ��
 �������  � ��
 ���� ��  �@�Cursor$
 Hand����  � �� �� "	 ��.R��� #��z��$ 0��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#FF6F6FP�  � ��$
 True��. ���  � �� �#C92E3A