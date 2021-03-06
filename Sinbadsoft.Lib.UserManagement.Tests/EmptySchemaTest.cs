// <copyright file="EmptySchemaTest.cs" company="Sinbadsoft">
// Copyright (c) Chaker Nakhli 2010
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by 
// applicable law or agreed to in writing, software distributed under the License
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing
// permissions and limitations under the License.
// </copyright>
// <author>Chaker Nakhli</author>
// <email>chaker.nakhli@sinbadsoft.com</email>
// <date>2010/11/04</date>
using NUnit.Framework;

namespace Sinbadsoft.Lib.UserManagement.Tests
{
    public class EmptySchemaTest : DbTestBase
    {
        [Test]
        public void Login()
        {
            var membership = new UserManager(this.ConnectionFactory());
            var loginResult = membership.Login("joe@doe.com", "p@ssw0rd");
            Assert.AreEqual(LoginResult.UnknownUser, loginResult);
        }
    }
}