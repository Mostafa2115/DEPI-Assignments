using System;
using System.Collections.Generic;

namespace MyLinq
{
    public static class MyLinqExtensions
    {
        // 1. Where
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }

        // 2. Select
        public static IEnumerable<TResult> MySelect<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }

        // 3. First
        public static T MyFirst<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
                return item;
            throw new InvalidOperationException();
        }

        // 4. FirstOrDefault
        public static T MyFirstOrDefault<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
                return item;
            return default;
        }

        // 5. Last
        public static T MyLast<T>(this IEnumerable<T> source)
        {
            T result = default;
            bool found = false;
            foreach (var item in source)
            {
                result = item;
                found = true;
            }
            if (!found) throw new InvalidOperationException();
            return result;
        }

        // 6. LastOrDefault
        public static T MyLastOrDefault<T>(this IEnumerable<T> source)
        {
            T result = default;
            foreach (var item in source)
                result = item;
            return result;
        }

        // 7. Count
        public static int MyCount<T>(this IEnumerable<T> source)
        {
            int count = 0;
            foreach (var item in source)
                count++;
            return count;
        }

        // 8. Any
        public static bool MyAny<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
                return true;
            return false;
        }

        // 9. All
        public static bool MyAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (!predicate(item))
                    return false;
            return true;
        }

        // 10. Take
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
        {
            int i = 0;
            foreach (var item in source)
            {
                if (i++ < count)
                    yield return item;
                else
                    yield break;
            }
        }

        // 11. Skip
        public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
        {
            int i = 0;
            foreach (var item in source)
                if (i++ >= count)
                    yield return item;
        }

        // 12. Contains
        public static bool MyContains<T>(this IEnumerable<T> source, T value)
        {
            foreach (var item in source)
                if (EqualityComparer<T>.Default.Equals(item, value))
                    return true;
            return false;
        }

        // 13. Sum
        public static int MySum(this IEnumerable<int> source)
        {
            int sum = 0;
            foreach (var item in source)
                sum += item;
            return sum;
        }

        // 14. Min
        public static int MyMin(this IEnumerable<int> source)
        {
            int min = int.MaxValue;
            foreach (var item in source)
                if (item < min)
                    min = item;
            return min;
        }

        // 15. Max
        public static int MyMax(this IEnumerable<int> source)
        {
            int max = int.MinValue;
            foreach (var item in source)
                if (item > max)
                    max = item;
            return max;
        }

        // 16. Average
        public static double MyAverage(this IEnumerable<int> source)
        {
            int sum = 0, count = 0;
            foreach (var item in source)
            {
                sum += item;
                count++;
            }
            return (double)sum / count;
        }

        // 17. Distinct
        public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source)
        {
            var set = new HashSet<T>();
            foreach (var item in source)
                if (set.Add(item))
                    yield return item;
        }

        // 18. Reverse
        public static IEnumerable<T> MyReverse<T>(this IEnumerable<T> source)
        {
            var list = new List<T>(source);
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }

        // 19. Concat
        public static IEnumerable<T> MyConcat<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var item in first)
                yield return item;
            foreach (var item in second)
                yield return item;
        }

        // 20. ElementAt
        public static T MyElementAt<T>(this IEnumerable<T> source, int index)
        {
            int i = 0;
            foreach (var item in source)
                if (i++ == index)
                    return item;
            throw new ArgumentOutOfRangeException();
        }

        // 21. DefaultIfEmpty
        public static IEnumerable<T> MyDefaultIfEmpty<T>(this IEnumerable<T> source, T defaultValue = default)
        {
            bool empty = true;
            foreach (var item in source)
            {
                empty = false;
                yield return item;
            }
            if (empty)
                yield return defaultValue;
        }

        // 22. TakeWhile
        public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item)) yield break;
                yield return item;
            }
        }

        // 23. SkipWhile
        public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool yielding = false;
            foreach (var item in source)
            {
                if (!yielding && !predicate(item))
                    yielding = true;

                if (yielding)
                    yield return item;
            }
        }

        // 24. ToList
        public static List<T> MyToList<T>(this IEnumerable<T> source)
        {
            return new List<T>(source);
        }

        // 25. ToArray
        public static T[] MyToArray<T>(this IEnumerable<T> source)
        {
            return new List<T>(source).ToArray();
        }

        // 26. Union
        public static IEnumerable<T> MyUnion<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var set = new HashSet<T>();
            foreach (var item in first)
                if (set.Add(item)) yield return item;
            foreach (var item in second)
                if (set.Add(item)) yield return item;
        }

        // 27. Intersect
        public static IEnumerable<T> MyIntersect<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var set = new HashSet<T>(second);
            foreach (var item in first)
                if (set.Contains(item))
                    yield return item;
        }

        // 28. Except
        public static IEnumerable<T> MyExcept<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var set = new HashSet<T>(second);
            foreach (var item in first)
                if (!set.Contains(item))
                    yield return item;
        }

        // 29. Append
        public static IEnumerable<T> MyAppend<T>(this IEnumerable<T> source, T element)
        {
            foreach (var item in source)
                yield return item;
            yield return element;
        }

        // 30. Prepend
        public static IEnumerable<T> MyPrepend<T>(this IEnumerable<T> source, T element)
        {
            yield return element;
            foreach (var item in source)
                yield return item;
        }

        // 31. Single
        public static T MySingle<T>(this IEnumerable<T> source)
        {
            T result = default;
            int count = 0;
            foreach (var item in source)
            {
                result = item;
                count++;
                if (count > 1) throw new InvalidOperationException();
            }
            if (count == 0) throw new InvalidOperationException();
            return result;
        }

        // 32. SingleOrDefault
        public static T MySingleOrDefault<T>(this IEnumerable<T> source)
        {
            T result = default;
            int count = 0;
            foreach (var item in source)
            {
                result = item;
                count++;
                if (count > 1) throw new InvalidOperationException();
            }
            return result;
        }

        // 33. Range
        public static IEnumerable<int> MyRange(int start, int count)
        {
            for (int i = 0; i < count; i++)
                yield return start + i;
        }

        // 34. Repeat
        public static IEnumerable<T> MyRepeat<T>(T element, int count)
        {
            for (int i = 0; i < count; i++)
                yield return element;
        }

        // 35. SequenceEqual
        public static bool MySequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
                if (!EqualityComparer<T>.Default.Equals(e1.Current, e2.Current))
                    return false;

            return !e1.MoveNext() && !e2.MoveNext();
        }

        // 36. Zip
        public static IEnumerable<TResult> MyZip<T1, T2, TResult>(
            this IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, T2, TResult> selector)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
                yield return selector(e1.Current, e2.Current);
        }

        // 37. Chunk
        public static IEnumerable<List<T>> MyChunk<T>(this IEnumerable<T> source, int size)
        {
            var chunk = new List<T>(size);

            foreach (var item in source)
            {
                chunk.Add(item);
                if (chunk.Count == size)
                {
                    yield return new List<T>(chunk);
                    chunk.Clear();
                }
            }

            if (chunk.Count > 0)
                yield return chunk;
        }

        // 38. Aggregate
        public static TAccumulate MyAggregate<T, TAccumulate>(
            this IEnumerable<T> source,
            TAccumulate seed,
            Func<TAccumulate, T, TAccumulate> func)
        {
            var result = seed;
            foreach (var item in source)
                result = func(result, item);
            return result;
        }

        // 39. OfType
        public static IEnumerable<TResult> MyOfType<TResult>(this IEnumerable<object> source)
        {
            foreach (var item in source)
                if (item is TResult result)
                    yield return result;
        }

        // 40. Cast
        public static IEnumerable<TResult> MyCast<TResult>(this IEnumerable<object> source)
        {
            foreach (var item in source)
                yield return (TResult)item;
        }
    }
}
