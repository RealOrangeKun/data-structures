using Xunit;

namespace HashTable;

public class HashTableTests
{
    [Fact]
    public void Add_IncreasesCount()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        var key = "testKey";
        var value = 42;

        // Act
        hashTable.Add(key, value);

        // Assert
        Assert.Equal(1, hashTable.Count);
    }

    [Fact]
    public void Add_UpdatesValue_WhenKeyExists()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        var key = "testKey";
        hashTable.Add(key, 42);

        // Act
        hashTable.Add(key, 43); // Updating value

        // Assert
        Assert.True(hashTable.TryGetValue(key, out var value));
        Assert.Equal(43, value);
    }

    [Fact]
    public void ContainsKey_ReturnsTrue_WhenKeyExists()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        var key = "testKey";
        hashTable.Add(key, 42);

        // Act
        var containsKey = hashTable.ContainsKey(key);

        // Assert
        Assert.True(containsKey);
    }

    [Fact]
    public void ContainsKey_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();

        // Act
        var containsKey = hashTable.ContainsKey("nonExistentKey");

        // Assert
        Assert.False(containsKey);
    }

    [Fact]
    public void Remove_DecreasesCount_WhenKeyExists()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        var key = "testKey";
        hashTable.Add(key, 42);

        // Act
        var removed = hashTable.Remove(key);

        // Assert
        Assert.True(removed);
        Assert.Equal(0, hashTable.Count);
    }

    [Fact]
    public void Remove_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();

        // Act
        var removed = hashTable.Remove("nonExistentKey");

        // Assert
        Assert.False(removed);
    }

    [Fact]
    public void Clear_ResetsCountToZero()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        hashTable.Add("testKey", 42);

        // Act
        hashTable.Clear();

        // Assert
        Assert.Equal(0, hashTable.Count);
    }

    [Fact]
    public void TryGetValue_ReturnsTrue_AndValue_WhenKeyExists()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();
        var key = "testKey";
        var value = 42;
        hashTable.Add(key, value);

        // Act
        var found = hashTable.TryGetValue(key, out var retrievedValue);

        // Assert
        Assert.True(found);
        Assert.Equal(value, retrievedValue);
    }

    [Fact]
    public void TryGetValue_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        var hashTable = new HashTable<string, int>();

        // Act
        var found = hashTable.TryGetValue("nonExistentKey", out var value);

        // Assert
        Assert.False(found);
        Assert.Equal(default(int), value); // Default value for int
    }

    [Fact]
    public void Resize_WhenLoadFactorThresholdIsExceeded()
    {
        // Arrange
        var hashTable = new HashTable<int, int>();
        for (int i = 0; i < 12; i++) // 12 items to exceed load factor of 0.75
        {
            hashTable.Add(i, i * 10);
        }

        // Act
        var key = 5;
        var found = hashTable.TryGetValue(key, out var value);

        // Assert
        Assert.True(found);
        Assert.Equal(key * 10, value);
    }
}

