namespace BusShuttle.Tests;

using BusShuttle;

public class fileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public fileSaverTests(){
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);

    }

    [Fact]
    public void Test_FileSaver_Append()
    {   
        fileSaver.AppendLine("Hello, World");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World"+Environment.NewLine, contentFromFile);

    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {   
        Stop sampleStop = new Stop("SampleStop");
        Loop sampleLoop = new Loop("SampleLoop");
        Driver sampleDriver = new Driver("SampleDriver");
        PassengerData sampleData = new PassengerData(5, sampleStop, sampleLoop, sampleDriver);

        fileSaver.AppendData(sampleData);
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("SampleDriver:SampleLoop:SampleStop:5"+Environment.NewLine, contentFromFile);

    }
}