﻿namespace ServerCore
{
    class Program
    {
        // 1. 근성
        // 2. 양보
        // 3. 갑질
        
        // 상호배제
        // Monitor
        private static object _lock = new object();
        private static SpinLock _lock2 = new SpinLock();
        private static ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();
        // 직접 만든다
        
        // [ ] [ ] [ ] [ ] [ ]
        class Reward
        {
            
        }

        static Reward GetRewawrdBtId(int id)
        {
            _lock3.EnterReadLock();
            
            _lock3.ExitReadLock();
            return null;
        }
        
        static void AddReward(Reward reward)
        {
            _lock3.EnterWriteLock();
            
            _lock3.ExitWriteLock();
        }
        private static void Main(string[] args)
        {
            lock (_lock)
            {
                
            }
            
            bool lockTaken = false;
            try
            {
                _lock2.Enter(ref lockTaken);
            }
            finally
            {
                if(lockTaken)
                    _lock2.Exit();
            }
        }
    }
}
