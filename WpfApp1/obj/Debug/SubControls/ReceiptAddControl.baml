   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfApp1.SubControlsWpfApp1.SubControls  5      -clr-namespace:WpfApp1.ToolsWpfApp1.Tools  5      +    %WpfApp1.SubControls.ReceiptAddControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WpfApp1.SubControls     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'Toolsclr-namespace:WpfApp1.Tools  5      ���#eee.��5      � ���#222.+�5   
   � -   5          �Name$  	RightGrid��5      $��454,0,0.2,0q�6"   .+�5      �� -   5         ��Name$ ProductView��5      ���#eee$��0,197,10,10q�6>   $��11��6i   ��6S   Z�  � BindingGroup 5      &   System.Windows.Data.BindingGroup  5       �� View 5      �� 5      .P�5      �� $��No��5   	    �� Width$ 50��6    �� DisplayMemberBinding 5   	   �� *No+5      �� 5      $��Quantity��5   	   $ 90��6    5   	   �� *
Quantity+5      �� 5      $
��Name��5   	   $	 190��6    5   	   �� *Name+5      �� 5      $��Category��5   	   $	 120��6    5   	   �� *
Category+5      �� 5      $��Price��5!   	   $ 70��6    5    	   �� *Price+ �� CellTemplate 5"      �� 5#   "   5%      5&      5(      � 5)      $	��187��6   $��
10,10,10,0q�6    $	��Top=�64    J� RenderTransformOrigin$ 0.489,0.549&�6L    � RowDefinitions 5*      �� 5+      .+�5-      �� -   5        	 ��Name$	 label��5-      $��Products��6'   $
��Left=�6:   $��10,5,0,0q�6U   $	��Top=�6g   $��14(�6   �� 5.      -   5        
 ��Name$
 ProductName��5/      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��50       �� 
IsEditable .    HintOpacity$ .5Q�52      $��	10,69,0,0q�6@   $
��Left=�6S   $	��Top=�6n   $	��171��6�   $��7��6�   �� 53      -   5         ��Name$ PriceBox��53      $ Price��6,   $
��Left=�6S   $��31��6n   $��
10,107,0,0q�6z    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��79��6�    �� TextAlignment$ Center=�6�   $��14(�6�   $��8��66  �� 54      -   5        $	 CurrencyLabel1��54      $	��PLN��60   $
��Left=�6>   $��14(�6Y   $��
94,107,0,0q�6g   $	��Top=�6{   $��31��6�   $��57��6�   �� 55      -   5         ��Name$ AddProduct_Btn��55       &  "MaterialDesignFloatingActionButton#��[  56       � ToolTip$ Add Product to the list��57      $��324,41,160.8,51q�67   $��10��6m   .��58      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6.   $��24��69   $��24��6E   59      �� 5:      -   5        $
 MarketTextBox��5;      $ Market��5<      $@ :Enter a name of the shop, you're entering the receipt from��5=       . $ .5Q�5?      $��	10,35,0,0q�6@   $
��Left=�6S   $	��Top=�6n   $	��120��6�   $��6��6�   �� 5@      -	   5        $ QuantityBox��5@      $
��Left=�6/   $��31��6J   $��
10,143,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $��79��6�   $ Center=�6�   $��14(�6�   $��1��6  $��9��6  �� 5A      -
   5        $	 QuantityLabel��5A      $��Quantity��6/   $
��Left=�6B   $��14(�6]   $��
94,146,0,0q�6k   $	��Top=�6   $��31��6�   $��70��6�   �� 5B      -   5        $ 
DeleteItem��5B      #��[  5C      $; 5Select an item on the list, then click this to delete��5D      $��508,157,-0.2,0.2q�6U   $
��Auto��6�   $
��Auto��6�   .��5E        $ Trash=�6.   $��24��6;   $��24��6G   5F      5G      5H      � 5I   
   -   5        $  LeftGrid��5I      $��0,0,566.2,0q�6!   .+�5J      � $��Stretch=�6   $	��205��61   $��40,40,205,0q�6>   $	��Top=�6S   .+�5K      (  "System.Windows.Controls.DatePicker  -   5          Name$ DateOfReceipt��5K      ���#eee$
 Date��6F   $
��Left=�6l   $��	10,10,0,0q�6�   $	��Top=�6�   $	��180��6�   $��1��6�   �� 5L      -   5        $
 CategoryBox��5M      $ Category��5N       .   & "MaterialDesignFloatingHintComboBox#��[ 5P      $ .5Q�5Q      $��	10,40,0,0q�6@   $
��Left=�6S   $	��Top=�6n   $	��178��6�   $��2��6�   � 5R      -   5        $  
RepeatGrid��5R      $��0,0,-0.2,-31q�6+   .+�5S      �� -   5         ��Name$ RepeatCheckBox��5S      $��Repeat��67   $
��Left=�6H   $��
10,167,0,0q�6c   $	��Top=�6w   $��4��6�   �� 5T      -   5        $
 RepeatanceBox��5U       .  $��
89,162,0,0q�5W      $
��Left=�6*   $	��Top=�6E   $��99��6]    �� SelectedIndex$ 0��6h   $��5��6z   .@�5X      �� $��Daily��6'   �� 5Y      $��Weekly��6'   �� 5Z      $��Monthly��6'   �� 5[      $��Yearly��6'   5\      �� 5]      -   5        $ ExpenseTitle��5]      $ Title��64   $
��Left=�6[   $��31��6v   $��
10,101,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��178��6�   $ Center=�6�   $��3��6�   5^      5_      �� 5`      -   5        $	 
TitleLabel��5`      $��	new order��6(   $
��Left=�6<   $��
20,2,0,456q�6W   ���	#FFEEEEEE � ForceCursor . $��20(�6�   $��Light"�6�   �� 5a      -   5        $ DiscountBox��5a      $ Discount��6+   $
��Left=�6U   $��31��6p   $��
66,353,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $��65��6�   $
 Left=�6�   $��14(�6�   $��12��66  �� 5b      -   5        $	 label1��5b      $��-��6$   $
��Left=�60   $��14(�6K   $��
40,353,0,0q�6Y   $	��Top=�6m   $��31��6�   $��23��6�   $��RightToLeft=�6�   �� 5c      -   5        $	 CurrencyLabel2��5c      $	��PLN��6,   $
��Left=�6:   $��14(�6U   $��136,353,0,0q�6c   $	��Top=�6x   $��31��6�   $��57��6�   �� 5d      -   5        $ TotalBox��5d      $ Total Order��6(   $
��Left=�6U   $��40��6p   $��225,353,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   $ Center=�6�   $��22(�6�   $��13��6:  �� 5e      -   5        $ 
ApproveBtn��5e        MaterialDesignRaisedButton#��[ 5f      $��288,429,40,28q�5g      $
��Auto��6(   $��APPROVE��66   5h      � 5i      -   5         �Name$ ProgressBarSaving��5i      $
��Left=�65   $��4��6P   $��288,473,0,0q�6[   $	��Top=�6p   $	��121��6�   �� 5j      -   5        $	 CurrencyLabel3��5j      $	��PLN��6,   $
��Left=�6:   $��22(�6U   $��382,353,0,0q�6c   $	��Top=�6x   $��31��6�   $��57��6�   5k      5l      5m      