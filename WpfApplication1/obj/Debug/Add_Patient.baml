   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:HMS.Models
HMS.Models  5   	       HMS.Add_Patient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:HMS.Models     5   	   -   5          � 
ResizeMode$  NoResize=�5   #    � WindowStyle$
 None=�69    � Title$ Add_Patient��5   	   $��261.941��6   $��271.804��6.   ���	#FF4F4F4F$��1q�6V    � 	Resources 5	         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5
   
   $ images/save.png?�6+   �� 5   
   8��  64   �� 5   
   $ images/cancel.png?�6-   �� 5   
   8��  66   5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ 	#FF8CCAFF��6   	 � Offset$	 1Q�6-   � 5      $ White��6   5      .��5      � -   5        .+�5   
   �� -   5        
 ��Name$
 label��5      $
��Name��6   $
��Left=�6.   $	��Top=�6I   $��	35,29,0,0q�6a   �� 5   
   -   5        $
 label1��5      $��Gender��6    $
��Left=�61   $	��Top=�6L   $��	35,60,0,0q�6d   �� 5   
   -   5        $
 label2��5      $��Date of Birth
��6    $
��Left=�6B   $	��Top=�6]   $��
35,114,0,0q�6u   $��85��6�   $��31��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ txtDob��5      $
��Left=�6%   $��125,114,0,0q�6@   $	��Top=�6U   $��4��6m   �� 5      -   5         ��Name$ txtName��5      $
��Left=�6�   $��23��6�   $��
125,32,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��1��6�    � ToolTip 6'   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�.��6
  ��5      �� 5      $
 Name�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� NotifyOnValidationError .  �� ValidationRules 5       5  /System.Windows.Controls.ExceptionValidationRule  5!      5#      .��5$      5%      �� 5&   
   -   5         ��Name$ btnSave��5&      #��[ 6"   $
��Left=�6G   $	��Top=�6b   $��48��6z   $��197,198,0,0q�6�   $��54��6�    J� RenderTransformOrigin$ 1.487,0.579&�6�   $��6��6  ��6�   Z� ��6�   Z� 6  �� 5'   
   -	   5        $ 	btnCancel��5'      #��[ 6$   $
��Left=�6K   $	��Top=�6f   $��26��6~   $��	246,0,0,0q�6�   $��23��6�   ��6�   Z� ��6�   Z� �� 5(   
   -
   5        $
 label3��5(      $��Category��6    $
��Left=�63   $	��Top=�6N   $��
35,150,0,0q�6f   $��81��6z   $ 
0.525,0.62&�6�   �� 5)   
   -   5         ��Name$ comboCat��5)      $
��Left=�6�   $	��Top=�6�   $	��120��6�   $��125,154,0,0q�6�   $��5��6�    6%   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent� �� Text 5*      �� 5+      $ Category�6    . $ PropertyChanged=�5-       .  5/        50      52      54      	� 56   
   -   5         	�Name$ radioFemale��56   )    	� 	GroupName$ gender��6   $��Female��6>   $
��Left=�6O   $	��Top=�6j   $��
125,91,0,0q�6�   $��3��6�   	� 57   
   -   5        $ 	radioMale��57   ;    d� 	IsChecked$
 TrueY�6   $ gender��6'   $
��Male��6N   $
��Left=�6]   $	��Top=�6x   $��
125,71,0,0q�6�   $��2��6�   59      5:      