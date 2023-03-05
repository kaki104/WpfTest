using System;

namespace PrismStep7.Models
{
    /// <summary>
    /// 애플리케이션 전체에서 유지되어야하는 데이터 - 싱글톤으로 유지
    /// </summary>
    public class AppContext : IAppContext
    {
        /// <summary>
        /// 로그인 유저 아이디
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 로그인 유저 이름
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 접속시간
        /// </summary>
        public DateTime Connection { get; set; }
        /// <summary>
        /// 접속아이디
        /// </summary>
        public Guid ConnectionId { get; set; } = Guid.NewGuid();
    }
}
