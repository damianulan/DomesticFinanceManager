   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfApp1.SubControlsWpfApp1.SubControls  5      ,    &WpfApp1.SubControls.ReceiptViewControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:WpfApp1.SubControls  5      ���#eee.��5
      � ���#222.+�5   
   � $
��Left=�6   $	��279��6*   $��	20,12,0,0q�67   $	��Top=�6J   $	��300��6b   .+�5      �� -   5          ��Name$  NameListBox��5      $��	133,0,0,0q�5   >    � Cursor$
 Hand��6Q   {�6   �� *	IsChecked+ �� ElementName$ EnableListBox��5      �� 5      -   5         ��Name$ CategoryBox��5      $
��Left=�6,   $	��Top=�6G   $	��100��6_   $��40��6k   $��	10,15,0,0q�6w   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Category��5       �� 
IsEditable .   &  "MaterialDesignFloatingHintComboBox#��[  5      .@�5      ��  �� 
IsSelected . .��5      All5      5      5      � 5   
   $
��Left=�6   $	��190��6*   $��
20,296,0,0q�67   $	��Top=�6K   $	��300��6c    � RowDefinitions 5      �� 5      .+�5      )   #WpfApp1.SubControls.ExpensesToMonth  $
��Left=�6$   $	��160��6?   $	��Top=�6L   $	��300��6d   $��0,30,0,0q�6p   �� 5      -   5         ��Name$ label��5      $��Last 4 months��6#   $
��Left=�6;   $��30,0,0,0q�6V   $	��Top=�6h   $��16(�6�   $��Segoe UI Light)�6�   5      �� 5    
   -   5        	 ��Name$	 ProductView��5       ���#eee$��401,231,10.2,10q�6:   $��11��6i   ��6S   Z� 
 � BindingGroup
 5!      &   System.Windows.Data.BindingGroup  5"       �� View 5$      �� 5%      .P�5&      �� $��No��5(       �� Width$ 50��6%    �� DisplayMemberBinding 5'      �� *No+5(   %   �� 5)      $��Quantity��5+      $ 90��6+    5*      �� *
Quantity+5+   +   �� 5,      $
��Name��5.      $	 190��6'    5-      �� *Name+5.   '   �� 5/      $��Price��51      $ 70��6(    50      �� *Price+ �� CellTemplate 52      �� 53      55      56      58      � 59   
   -   5         �Name$ 
DetailGrid��59      .+�5:      �� -   5        $ label1��5:      $��Date:��6$   $
��Left=�64   $��
416,46,0,0q�6O   $	��Top=�6c   $��Segoe UI Light)�6{   $��18(�6�   �� 5;      -   5        $ label1_Copy��5;      $��Total:��6)   $
��Left=�6:   $��
417,93,0,0q�6U   $	��Top=�6i   $��Segoe UI Light)�6�   $��18(�6�   �� 5<      -   5        $ label1_Copy1��5<      $��	Discount:��6*   $
��Left=�6>   $��401,132,0,0q�6Y   $	��Top=�6n   $��Segoe UI Light)�6�   $��14(�6�   � 5=      -	   5        $ RepeatanceGrid��5=      .+�5>      �� -
   5        $ RepeatenceLabel��5>      $��Repeat every:��61   $
��Left=�6I   $��756,100,0,0q�6d   $	��Top=�6y   $��Segoe UI Light)�6�   $��14(�6�   �� 5?      -   5        $ RepeatanceBox��5@       .  $��849,100,0,0q�5B      $
��Left=�6"   $	��Top=�6=   $��69��6U    �� SelectedIndex$ 0��6`   $��5��6r   .@�5C      �� $	��Day��6#   �� 5D      $
��Week��6#   �� 5E      $��Month��6#   �� 5F      $
��Year��6#   5G      5I      �� 5J      -   5        $ DetailsLabel��5J      $��Product Details��6*   $
��Left=�6D   $��401,199,0,0q�6_   $	��Top=�6t   $��Segoe UI Light)�6�   $��18(�6�   �� 5K      -   5        $ 	DateLabel��5K      $��No data��6'   $
��Left=�69   $��
468,46,0,0q�6T   $	��Top=�6h   $��Segoe UI Light)�6�   $��18(�6�   �� 5L      -   5        $ 
TotalLabel��5L      $��No data��6(   $
��Left=�6:   $��
468,93,0,0q�6U   $	��Top=�6i   $��Segoe UI Light)�6�   $��18(�6�   �� 5M      -   5        $ DiscountLabel��5M      $��No data��6+   $
��Left=�6=   $��468,132,0,0q�6X   $	��Top=�6m   $��Segoe UI Light)�6�   $��14(�6�   �� 5N      -   5        $ label1_Copy7��5N      $��Details��6*   $
��Left=�6<   $��
401,17,0,0q�6W   $	��Top=�6k   $��Segoe UI Light)�6�   �� 5O      -   5         ��Name$ 
DeleteItem��5O       & "MaterialDesignFloatingActionButton#��[ 5P       � ToolTip$; 5Select an item on the list, then click this to delete��5Q      $��67,127,916.245,337.302q�6U   $��32��6�   $��32��6�   .��5R      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Trash=�6*   $��24��67   $��24��6C   5S      5T      5V      5X      