   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   -clr-namespace:WpfApp1.ToolsWpfApp1.Tools  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'Toolsclr-namespace:WpfApp1.Tools  5   	   $	��600��5	      $
��1080��6'   ���#eee  � 
ResizeMode$  NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\    � WindowStyle$
 None=�6�    � 	Resources 5
         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5      .��5       � ���#222.+�5!   
   � -   5         �Name$ GridMain��5!      $��Right=�6!   $��Bottom=�6=   $	��559��6X   $
��1015��6e   .+�5"         WpfApp1.UserControlHome  $
��Left=�6$   $	��559��6?   $	��Top=�6L   $
��1015��6d   5#      � 5$   
   -   5        $ TopNav��5$      $��40��6   $	��Top=�6+   ���#333 J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5*      �� $��Center=�6   $��Center=�65   $��440,11,440,11q�6P   $
��Bold"�6g   �� 6z   $�DOMESTIC FINANCE MANAGER��6~   6�   � 5+      $��	893,0,0,0q�6   $
��Left=�6&   $	��187��6A      WpfApp1.Tools.IconButton  5,      -   5          Name$ ExitBtn��5,         WpfApp1.Tools.IconButton   	MouseDown$ ExitBtn_MouseDown��6�   $��40��60   $��	982,0,0,0q�6<   $	��Top=�6O      IconKind$ Close=�6g   $
��Left=�6x   $��40��6�   6�     5-      -   5        $ MinimizeBtn��5-      $ MinimizeBtn_MouseDown��6�   $��40��64   $��	938,0,0,0q�6@   $	��Top=�6S   $ WindowRestore=�6k   $
��Left=�6�   $��40��6�   6�   �� 5.       �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��
1022,0,0,0q�6M   .+�5/      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $
��10,0q�6e   $��40��6s   $��Bottom=�6   $��38��6�      PopupContent. 50      �� $	��120��6!   .+�51      �� $
��Info��6!   �� 52      $
��Help��6!   53      54      55      56      � 57   
   -   5        $ GridMenu��57      $��65��6!   $
��Left=�6,   ���#D66D0C 58        59      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5;      �� .+�5<      � $��60��6   ���#D66D0C J� RenderTransformOrigin$ 0.482,0.358&�68   z�5=      V� 5>      .~�5?      �� �� 5@      �� 5A      T� 5B      5C      .+�5E      �� -   5         ��Name$ ButtonOpenMenu��5E      $��60��65   $
��Auto��6A   $��0,0,0,0q�6N   $	��Top=�6_    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6w   ���#222��6�   Z� ��6�   Z� .��5F      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Menu=�62   $��25��6>   $��25��6I   5G      �� 5H      -   5        $ ButtonCloseMenu��5H      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��0,0,0,0q�6d   $��Right=�6u   $	��Top=�6�   #��[ 6�   ���#222��6�   Z� ��6  Z� .��5I        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5J      5K      �� 5L      -   5         ��Name$ ListViewMenu��5L      ���#222$��Disabled=�6C   $
��Left=�6�   $��
0,0,-0.2,0q�6�   $	��309��6�   .@�5M      �� -	   5         ��Name$ ItemHome��5M   #   $��60��65    � Cursor$
 Hand��6A   .��5N      �� $ 
Horizontal=�6%   .+�5O        $ ViewDashboard=�66   $��25��6K   $��25��6W   $��12.5, 10q�6b   �� 5P      $��	Dashboard��6(   $��Center=�69   $��20 10q�6T   5Q      5R      �� 5S      -
   5        $ ReceiptsControl��5S   #   $��60��6<   $
 Hand��6H   .��5T      �� $ 
Horizontal=�6%   .+�5U        $ Receipt=�66   $��25��6E   $��25��6Q   $��12.5, 10q�6\   �� 5V      $��Expenses��6(   $��Center=�68   $��20 10q�6S   5W      5X      �� 5Y      -   5        $ ProductsControl��5Y   #   $��60��6<   $
 Hand��6H   .��5Z      �� $ 
Horizontal=�6%   .+�5[        $
 Cart=�66   $��25��6B   $��25��6N   $��12.5, 10q�6Y   �� 5\      $��Products��6(   $��Center=�68   $��20 10q�6S   5]      5^      5_      5`      5a      5b      5c      