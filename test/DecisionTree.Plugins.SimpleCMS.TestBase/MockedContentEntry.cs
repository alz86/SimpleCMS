using DecisionTree.Plugins.SimpleCMS.Entities;
using System;

namespace DecisionTree.Plugins.SimpleCMS;

/// <summary>
/// Class that inherits from <see cref="ContentEntry"/>.
/// Its sole purpose is to expose the <see cref="ContentEntry.Id"/> property
/// in a writable manner. This allows for setting known id values
/// and facilitates subsequent checks.
/// </summary>
public class MockedContentEntry : ContentEntry
{
    public Guid WritableId
    {
        get => base.Id;
        set => base.Id = value;
    }
}
