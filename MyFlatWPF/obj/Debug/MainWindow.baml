   M S B A M L   `   `   `  ����D  @MyFlatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyFlatWPF	MyFlatWPF  5   	   9!clr-namespace:MyFlatWPF.ViewModelMyFlatWPF.ViewModel  5   	   =#clr-namespace:MyFlatWPF.HelpMethodsMyFlatWPF.HelpMethods  5   	       MyFlatWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MyFlatWPF     5   	   7	viewModel!clr-namespace:MyFlatWPF.ViewModel     5   	   4help#clr-namespace:MyFlatWPF.HelpMethods     5   	     � Title$  MyFlat��5
   	    � Icon$ /Images/i.ico��5   	   $	��610��5   	   $	��610��5   	   $	��680��5   	   $	��680��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      -   'MyFlatWPF.ViewModel.MainWindowViewModel   MainWindowViewModel1  +MyFlatWPF.HelpMethods.MyMultiValueConverter  MyMultiValueConverter��%:   &	        &	        5   
   6(     5   
   6%   5      .��5      � -   5         �Name$ gTopMenu��5       5   
     ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType  TextBlockStyle  
ImageStyle��%[  &	       &	     &	 �    �� 5      " ��6(   .�5      ��  �@�OverridesDefaultStyle . 6:   �� 5"       � �� 5#      �� 5$      " ��6*   .R�5%      �� #��z��6%   ._�5&   "   �� $��Center=�63   $��Center=�6P   $��1 0 1 0q�6k   5'      5(      5*      5+      �� 5-      " ��6+   .�5.      ��  � ��$ 15(�6-   �� 5/       � ��$ 0q�6+   �� 50       � ��
 ���� 6/   51      �� 53      " ��6'   .�54      ��  � ��$ 28��6+   �� 55       � ��$ 50��6*   �� 56       � ��$ 0 0 2 0q�6+   57      59      	 � RowDefinitions	 5;   
   �� 5<      $��7* �6   �� 5=      $
��4.5* �6   �� 5>      $��2* �6   �� 5?      $
��140* �6   
 � ColumnDefinitions
 5A   
   �� 5B      $	��45* �6   $	��450��6+   6<   �� 5C      $	��19* �6   $	��190��6+   6<   .+�5H   
   �� -   5         ��Name$ mTopLeft��5H      $��0��5I      $��25��5J       �� Orientation$ 
Horizontal=�5K      $	��430��5L      $	��Top=�5M      $
��Left=�5N      $��10 0 0 0q�5O      
������� � DataContext 5Q      ��  �� Mode$ OneWay=� �� Source# [  5�      o� 5�   
   -   5         o�Name$ 	mTopRight��5�      $��1��5�      $��24��5�      $
��auto��5�      $	��Top=�5�      $��Right=�5�      $��15(�5�      
�������.@�5�      m� -   5         m�Name$ miLogIn��5�      $��Login��5�       � Cursor$
 Hand��5�      $��0 0 2 0q�5�      5�      m� 5�      -   5        $ 
miRegister��5�      $��Register��5�      
���   �$��0 0 2 0q�5�      $
 Hand��5�      5�      m� 5�      -   5        $ 
miUserName��5�      $y�	Collapsed=�5�      $�� ��5�      
���P��$ Arrow��5�      $��0 0 2 0q�5�      5�      m� 5�      -   5        $ miLogOut��5�      $y�	Collapsed=�5�      $��Logout��5�      $
 Hand��5�      $��0 0 2 0q�5�      5�      5�      �� 5�   
   -   5         ��Name$ tbRandomPhrase��5�      $��1��5�      $��1��5�      $��ECO-FRIENDLY HOUSES��5�      $��0 0 10 0q�5�      $��Right=�5�      $��12(�5�      $��DemiBold"�5�      
������ 5�      �� 5�   
   $��2��6   $��2��5�      
���   �$��1��5�      5�      �� 5�   
   $��3��6   $��2��5�      ��5�      �� 5�       �� 
StartPoint$ 0.5, 0&�6&    �� EndPoint$ 0.5, 1&�6:   .��5�      �  � Color$ Transparent��6#    � Offset$	 0.0Q�67   � 5�      $ Transparent��6#   $	 0.3Q�67   � 5�      $ #8ed5ff��6#   $
 0.85Q�63   5�      ._�5�      �� -	   5        $ 	spContent��5�      $��3��5�      $��2��5�      .+�5�      �� -
   5         ��Name$ ccView��5�   !   ��5�      �� *CurrentView+# [   �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      5�      5�      5�      