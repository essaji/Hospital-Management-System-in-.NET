   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSHMS  5   	       HMS.Add_Medicine   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:HMS     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � WindowStyle$
  None=�5   $    � 
ResizeMode$ NoResize=�67    � Title$ Add_Medicine��5	   	   $	��187��6   $	��305��6+   $��1q�6T   ���	#FF5D5D5D � 	Resources 5
         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5   
   $ images/save.png?�6+   �� 5   
   8��  64   �� 5   
   $ images/cancel.png?�6-   �� 5   
   8��  66   5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFF1A83F��6    � Offset$ 1Q�6-   � 5      $ White��6   5      .��5      � .+�5   
   � $��Center=�6   $��Center=�6,   .+�5      �� -   5        	 ��Name$	 
txtMedName��5   �   $��2q�6   
 �� TextWrapping$
 NoWrap=�6�   $
��Left=�6�   $��25��6�   $��
110,10,0,0q�6�   $	��Top=�6�   $	��120��6   � ToolTip 6"   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�.��6  ��5      �� 5      $ MedName�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� NotifyOnValidationError .  �� ValidationRules 5      5  /System.Windows.Controls.ExceptionValidationRule  5      5!      .��5"       5#      �� 5$      -   5         ��Name$ label2��5$      $��Medicine Name��6$   $
��Left=�6<   $��11,7,0,0q�6W   $	��Top=�6i   �� 5%      -   5        $ label3��5%      $��Price��6$   $
��Left=�64   $��	65,50,0,0q�6O   $	��Top=�6b    J� RenderTransformOrigin$ 1.167,0.538&�6z   $��40��6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5&      -   5          Name$ txtMedPrice��5&   !   $��Center=�6�   $	��Top=�6�   $	��120��6�   $��30��6�   $��9��6�   $��110,50,19,0q�6�    66   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5'      �� 5(      $ MedPrice�6    . $ PropertyChanged=�5*       .  5,        5-      5/      51      �� 52      -   5         ��Name$ 	btnAddMed��52      #��[ 6(   $
��Left=�6M   $��
192,97,0,0q�6h   $	��Top=�6|   $��57��6�   $��40��6�   ��6�   Z� ��6�   Z� �� 53      -   5        $ 	btnCancel��53      #��[ 6(   $
��Left=�6O   $��247,-22,-20,0q�6j   $	��Top=�6�   $��22��6�   $��28��6�   $ -0.567,0.514&�6�   ��6�   Z� ��6  Z� 54      55      56      