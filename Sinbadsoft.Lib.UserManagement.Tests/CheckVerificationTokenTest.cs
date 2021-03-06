// <copyright file="CheckVerificationTokenTest.cs" company="Sinbadsoft">
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
// <date>2012/08/20</date>
using NUnit.Framework;

namespace Sinbadsoft.Lib.UserManagement.Tests
{
    [TestFixture]
    public class CheckVerificationTokenTest : DbTestBase
    {
        private IUserManager membership;

        [SetUp]
        public void SetUp()
        {
            TestData.InsertData(this.ConnectionFactory(), true);
            this.membership = new UserManager(this.ConnectionFactory());
        }

        [Test]
        public void VerificationTokenCantBeClearedIfPasswordIsNotSet()
        {
            var id = TestData.AnneEmailNotVerifiedPasswordNotSet.Id;
            var token = new VerificationToken(TestData.AnneEmailNotVerifiedPasswordNotSet.VerificationToken);
            Assert.AreEqual(VerifyResult.InvalidPassword, this.membership.CheckAndClearVerificationToken(id, token));
        }

        [Test]
        public void VerificationTokenClearedIfValidPassword()
        {
            var id = TestData.AnneEmailNotVerifiedPasswordNotSet.Id;
            var token = new VerificationToken(TestData.AnneEmailNotVerifiedPasswordNotSet.VerificationToken);
            Assert.AreEqual(VerifyResult.Success, this.membership.CheckAndClearVerificationToken(id, token, "password123;"));
        }
    }
}