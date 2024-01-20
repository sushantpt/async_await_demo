using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_demo.Classes
{
    public class AsyncMode
    {
        public async Task A()
        {
            await B();
        }

        private async Task B()
        {
            await C();
        }

        private async Task C()
        {
            await D();
        }

        private async Task D()
        {
            await E();
        }

        private async Task E()
        {
            await F();
        }

        private async Task F()
        {
            await Task.Delay(1000);
        }

    }
}
