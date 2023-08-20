﻿using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;

namespace DemoCode.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
