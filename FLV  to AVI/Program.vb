'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


' x64 IMPORTANT NOTE: set CPU to x86 to build in x86 mode. WHY? Because flash is not supported on x64 platform currently at all

Imports System.Diagnostics
Imports BytescoutSWFToVideo

Class Program
	Friend Shared Sub Main(args As String())
		' Create an instance of SWFToVideo ActiveX object
		Dim converter As New SWFToVideo()

		' Set debug log
		'converter.SetLogFile("log.txt");

		' Register SWFToVideo
		converter.RegistrationName = "demo"
		converter.RegistrationKey = "demo"

		' Set the converter to the live data conversion mode
		' (it will fully load the embedded video stream before the conversion)
		converter.SWFConversionMode = SWFConversionModeType.SWFWithLiveData

        	' Set input SWF file
	        converter.InputSWFFileName = "..\..\..\..\video.flv"


	        ' Set output AVI or WMV video file 
        	converter.OutputVideoFileName = "result.avi"

		' Don't let it run infinitely
	        converter.ConversionTimeOut = 3000 ' 3000ms = 3 seconds 

		' you may calculate output video duration using information about the the source swf movie
		' WARNING #1: this method to calculate the output video duration is not working for movies with dynamic scenes 
		' and interactive scripts as in these movies it is not possible to calculate the precise duration of the movie 
		' WARNING #2: you should set the input swf or flv filename (or url) before this calculation

		' So the movie duration is calculated as the following:
		' as swf frame count (number of frames in the swf) / movieFPS (frames per second defined in swf)
		' and then multiplied by 1000 (as we are setting the .ConverstionTimeout in milliseconds)
		' as the following (uncomment if you want to set the length of the output video to the same as the original swf)
		' or as the following source code (uncomment to enable):

		' converter.ConversionTimeout = 1000 * (converter.FrameCount / converter.MovieFPS)


		' set FPS 
		converter.FPS = 29.97F

		' Set output movie dimensions 
		converter.OutputWidth = 320
		converter.OutputHeight = 240

		' Run conversion 
		converter.RunAndWait()

		' Open the result in default media player
        Process.Start("result.avi")
	End Sub
End Class
