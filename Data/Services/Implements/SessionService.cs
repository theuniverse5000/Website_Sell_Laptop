namespace Data.Services.Implements
{
    public static class SessionService
    {
        // 1 Đọc dl từ session =>  trả về 1 list
        //public static List<CartItemUseSession> GetObjFromSession(ISession session, string key)
        //{
        //    string jsonData = session.GetString(key);// lấy dữ liệu dạng string từ session
        //    if (jsonData == null)
        //    {

        //        return new List<CartItemUseSession>();// khởi tạo 1 list mới để chứa sp khi 
        //        // dữ liệu lấy ra null <=> Session chưa được tạo ra
        //    }
        //    else
        //    {
        //        var CartItemUseSessions = JsonConvert.DeserializeObject<List<CartItemUseSession>>(jsonData);
        //        return CartItemUseSessions;
        //    }
        //}
        //// 2. Ghi đè dữ liệu vào session từ 1 list
        //public static void SetObjToSession(ISession session, string key, object data)
        //{
        //    var jsonData = JsonConvert.SerializeObject(data);// chuyển đổi dữ liệu jsonData
        //    session.SetString(key, jsonData);// Ghi đè vào Session
        //}
        //// 3. Kiểm tra xem đối tượng có nằm trong 1 list hay không
        //public static bool CheckObjInList(Guid id, List<CartItemUseSession> CartItemUseSessions)
        //{
        //    return CartItemUseSessions.Any(x => x.IdProductDetail == id);
        //    // Any : một trong những , All : Tất cả
        //}
        ////public static void SetJson(this ISession session, string key, object value)
        ////{
        ////    session.SetString(key, JsonConvert.SerializeObject(value));
        ////}

        ////public static T GetJson<T>(this ISession session, string key)
        ////{
        ////    var sessionData = session.GetString(key);
        ////    return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        ////}
        //// 1 Đọc dl từ session =>  trả về 1 list
        //public static List<ProductDetailView> GetFromSession(ISession session, string key)
        //{
        //    string jsonData = session.GetString(key);// lấy dữ liệu dạng string từ session
        //    if (jsonData == null)
        //    {

        //        return new List<ProductDetailView>();// khởi tạo 1 list mới để chứa sp khi 
        //        // dữ liệu lấy ra null <=> Session chưa được tạo ra
        //    }
        //    else
        //    {

        //        var ProductDetailViews = JsonConvert.DeserializeObject<List<ProductDetailView>>(jsonData);
        //        return ProductDetailViews;
        //    }
        //}
        //// 2. Ghi đè dữ liệu vào session từ 1 list
        //public static void SetToSession(ISession session, string key, object data)
        //{
        //    var jsonData = JsonConvert.SerializeObject(data);// chuyển đổi dữ liệu jsonData
        //    session.SetString(key, jsonData);// Ghi đè vào Session
        //}
    }
}
