   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolPlatform.Views.ProfessorSchoolPlatform.Views.Professor  5   	   1    +SchoolPlatform.Views.Professor.ManageGrades   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SchoolPlatform.Views.Professor     5   	     � Title$  ManageGrades��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $
��24px(�6   $
��Left=�6    $��	12,10,0,0q�6;   $	��Top=�6N   $��44��6f   $	��398��6r   ��5      �� 5      $	��390��6   �� 5      $�
Grades of ��6    �� 5      �6   �� *CurrentStudent.StudentName+5      5      �� 5   
   $
��24px(�6   $��Right=�6    $��
392,10,0,0q�6<   $	��Top=�6P   $��44��6h   $	��398��6t   ��5      �� 5      $	��390��6   �� 5      $�	(Average:��6    �� 5      �6   �� *Average.AverageGrade+ �� 5      $�)��6   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � y� �� Value$ Visible=�6;    �� Triggers 5      �� 5   "    �� Binding 6.   �� *Average.AverageGrade+ �� Value 6W   Z� .a�5   &   ��  � y�$ 	Collapsed=�6C   5   #   5       5"      5$      �� 5%   
   -   5        $��10,69,10,80q�5%   �   ��6   �� *Grades+ �� SelectedItem 62   �� *SelectedGrade+��5&      �� 5'      " ��6   .�5(      ��  � ��$ 35��6/   5)       � 	Resources 5+      ��%T   '��       �� 5,      " ��6   .�5-      ��  � ��$
 Left=�6C   5.      5/      	 �� View	 50      �� 51      .P�52      �� $��Subject Grade��6%   
 �� Width$	
 100��6h    �� DisplayMemberBinding 6<   �� *
GradeValue+6h   �� 53      $��Is Final Exam Grade��6%   $	
 120��6o    6B   �� *IsFinalExam+6o   54      56      �� 57   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��12,359,0,10q�6I   .+�58      �� $
��18px(�6    �� TextWrapping$
 Wrap=�6&   $	��113��6V   $��Center=�6b   $��34��6}   ��6:   �� *
InputGrade+6}   �� 59      $��5q�69   $��Is Final��6D   $��Center=�6W    d� 	IsChecked 6   �� *IsFinalExam+6W   �� 5:      $��0��69   $��	Add Grade��6N   $	��100��6b   $��5q�6n   ��6   �� *AddGradeCommand+6n   �� 5;      $��Delete Grade��6<   $	��100��6S   $��5q�6_   ��6   �� *DeleteGradeCommand+6_   �� 5<      $��Update Grade��6<   $	��100��6S   $��5q�6_   ��6   �� *UpdateGradeCommand+6_   �� 5=      $��Calculate Average��6A   $	��114��6]   $��5q�6i   ��6   �� *CalculateAverageCommand+6i   �� 5>      $��Delete Average��6>   $	��114��6W   $��5q�6c   ��6   �� *DeleteAverageCommand+6c   5?      5@      5A      