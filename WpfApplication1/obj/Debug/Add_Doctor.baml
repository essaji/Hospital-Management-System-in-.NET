   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSHMS  5   	       HMS.Add_Doctor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:HMS     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ 
Add Doctor��5	   	   $��326.951��6   $��453.482��6-    � WindowStyle$
 None=�6=   $��1q�6m   ���	#FF292929 � 	Resources 5
         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5   
   $ images/save.png?�6+   �� 5   
   8��  64   �� 5   
   $ images/cancel.png?�6-   �� 5   
   8��  66   5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF86E09F��6    � Offset$ 1Q�6-   � 5      $ White��6   5      .��5      � $��Center=�6   $��Center=�6(   $	��327��6C   $��0,0,0,0q�6P   $	��449��6a   .+�5   
   �� -   5        	 ��Name$	 txtFirstName��5      $
��Left=�6�   $��23��6�   $��
100,51,0,0q�6�   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��1��6�   
�������$��Trebuchet MS)�6   � ToolTip 6(   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�.��69  ��5      �� 5      $ 	Firstname�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� NotifyOnValidationError .  �� ValidationRules 5      5  /System.Windows.Controls.ExceptionValidationRule  5      5!      .��5"      5#      �� 5$   
   -   5        $	 txtUsername��5$      $
��Left=�6�   $��23��6�   $��
323,48,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.507,-0.201&�6�   $��3��6!  $��Trebuchet MS)�6.   6'   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��6I  ��5%      �� 5&      $ Username�6    . $ PropertyChanged=�5(       .  5*        5+      5-      .��5.      5/      �� 50   
   -   5         ��Name$ label��50      $��
First Name��6   $
��Left=�64   $��	20,51,0,0q�6O   $	��Top=�6b   $ 1.086,0.545&�6z   $��Trebuchet MS)�6�   �� 51   
   -   5        $ lblUsername��51      $��Username��6%   $
��Left=�68   $��
245,45,0,0q�6S   $	��Top=�6g   $ 0.401,0.256&�6   $��Trebuchet MS)�6�   �� 52   
   -   5        $	 txtLastName��52      $
��Left=�6�   $��23��6�   $��
100,82,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   $��Trebuchet MS)�6	   6'   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��6$  ��53      �� 54      $ Lastname�6    . $ PropertyChanged=�56       .  58        59      5;      .��5<      5=      �� 5>   
   -   5        $ 
label_Copy��5>      $��	Last Name��6$   $
��Left=�68   $��	21,82,0,0q�6S   $	��Top=�6f   $ 1.086,0.545&�6~   $��Trebuchet MS)�6�   �� 5?   
   -   5        $	 txtPassword��5?      $
��Left=�6�   $��23��6�   $��
324,79,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��4��6�   $��Trebuchet MS)�6	   6'   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��6$  ��5@      �� 5A      $ Password�6    . $ PropertyChanged=�5C       .  5E        5F      5H      .��5I      5J      �� 5K   
   -	   5        $ label_Copy1��5K      $��Password��6%   $
��Left=�68   $��
246,79,0,0q�6S   $	��Top=�6g   $ 1.086,0.545&�6   $��Trebuchet MS)�6�   �� 5L   
   -
   5        $ label_Copy3��5L      $��Salary��6%   $
��Left=�66   $��277,154,0,0q�6Q   $	��Top=�6f   $ 1.086,0.545&�6~   $��Trebuchet MS)�6�   �� 5M   
   -   5        $	 txtPhone��5M      $
��Left=�6�   $��23��6�   $��
99,154,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��10��6�   $��Trebuchet MS)�6   6$   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��6"  ��5N      �� 5O      $ Phone�6    . $ PropertyChanged=�5Q       .  5S        5T      5V      .��5W      5X      �� 5Y   
   -   5        $ label_Copy4��5Y      $��Phone��6%   $
��Left=�65   $��
49,154,0,0q�6P   $	��Top=�6d   $ 1.086,0.545&�6|   $��Trebuchet MS)�6�   �� 5Z   
   -   5        $ label1_Copy��5Z      $��Gender��6%   $
��Left=�66   $	��Top=�6Q   $��
40,202,0,0q�6i   $��Trebuchet MS)�6}   	� 5[   
   -   5         	�Name$ radioFemale��5[   )    	� 	GroupName$ gender��6   $��Female��6>   $
��Left=�6O   $	��Top=�6j   $��111,220,0,0q�6�   $��8��6�   $��Trebuchet MS)�6�   	� 5\   
   -   5        $ 	radioMale��5\   <    d� 	IsChecked$
 TrueY�6   $ gender��6(   $
��Male��6O   $
��Left=�6^   $	��Top=�6y   $��111,200,0,0q�6�   $��7��6�   $��Trebuchet MS)�6�   �� 5]   
   -   5         ��Name$ btnSave��5]      #��[ 6"   $
��Left=�6G   $��338,240,0,0q�6b   $	��Top=�6w   $��69��6�   $��11��6�   $��59��6�   $��Trebuchet MS)�6�   ��6�   Z� ��6�   Z� �� 5^   
   -   5        $ 	btnCancel��5^      #��[ 6$   $
��Left=�6K   $��	409,3,0,0q�6f   $	��Top=�6y   $��34��6�   $��12��6�   $��27��6�   $��Trebuchet MS)�6�   ��6�   Z� ��6�   Z� (  "System.Windows.Controls.DatePicker  5_   
   -   5          Name$ txtDob��5_      $
��Left=�6�   $��100,125,0,0q�6�   $	��Top=�6�   $	��119��6�   $��5��6�   $��Trebuchet MS)�6�    6%   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�6�   �� 5`      -   5        $ label_Copy5��5`      $��Date of Birth��6)   $
��Left=�6A   $��
12,125,0,0q�6\   $	��Top=�6p   $ 1.086,0.545&�6�   $��Trebuchet MS)�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5b   
   -   5        $��	txtSalary��5b      $
��Left=�6�   $��324,154,0,0q�6�   $	��Top=�6�   $	��119��6�   $��26��6�   $��9��6�   $��Trebuchet MS)�6�    6.   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5c      �� 5d      $ Salary�6    . $ PropertyChanged=�5f       .  5h        5i      5k      5m      �� 5n   
   -   5         ��Name$ cboSpecialization��5n   �    �� DisplayMemberPath$
 name��6    �� SelectedValuePath$ catid��6�   $
��Left=�6�   $��322,125,0,0q�6�   $	��Top=�6�   $	��120��6  $��Trebuchet MS)�6   6,   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent� �� Text 5o      �� 5p      $ Category�6    . $ PropertyChanged=�5r       .  5t        5u      5w      5y      �� 5{   
   -   5        $ label_Copy7��5{      $��Specialization��6%   $
��Left=�6>   $��236,121,0,0q�6Y   $	��Top=�6n   $ 1.086,0.545&�6�   $��Trebuchet MS)�6�   5}      5~      