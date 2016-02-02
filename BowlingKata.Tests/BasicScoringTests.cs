using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Tests
{
    [TestClass]
    public class BasicScoringTests
    {
        [TestMethod]
        public void TestEquals300()
        {
            FrameCollection frames = new FrameCollection();

            Repeat(() =>
                {
                    frames.Add(new Frame(10,0));
                },10);

            frames.Add(new Frame(10, true));
            frames.Add(new Frame(10, true));

            Assert.IsTrue(frames.Score() == 300);
        }

        [TestMethod]
        public void TestEquals90()
        {
            FrameCollection frames = new FrameCollection();

            Repeat(() =>
                {
                    frames.Add(new Frame("9", "-"));
                }, 10);

            Assert.IsTrue(frames.Score() == 90);
        }

        [TestMethod]
        public void TestEquals150()
        {
            FrameCollection frames = new FrameCollection();

            Repeat(() =>
            {
                frames.Add(new Frame("5", "/"));
            }, 10);

            frames.Add(new Frame(5));

            Assert.IsTrue(frames.Score() == 155);
        }


        private void Repeat(Action onRepeat, int count)
        {
            int pass = 0;
            do
            {
                onRepeat();
                pass++;
            } while (pass < count);
        }
    }
}
