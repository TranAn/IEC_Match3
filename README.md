Xin chào!

Đầu tiên mình xin cám ơn đã được tham gia làm bài test trước phỏng vấn.

Buổi trưa mình đã down project về đọc và hoàn thành câu #2, #3, #4 trong các commits trên repo.

Riêng câu #1 về tối ưu hiệu năng game thì mình không có nhiều kinh nghiệm lắm + buổi tối mình bận
làm dự án ngoài nên không có thời gian để hoàn thành nên mình chỉ note một số điểm mình nhận thấy
trong project có thể tối ưu & cải thiện được ở bên dưới:

1. Board đang được hủy và tạo lại khi chuyển Mode hay GameOver thay vào đó có thể Init Board 1 lần
duy nhất khi Start game.
2. Tối ưu Render Board bằng 1 Sprite Tiled Mode thay vì render từng cell background (Bỏ SpriteRenderer
của cellBackground đi chỉ dùng cell để nhận xử lý Input).
3. View của Item cũng đang bị hủy và tạo lại thay vào đó chỉ cần thay sprite cho View.
4. Có thể dùng Sprite Atlas để tối ưu cho render Item.
5. Có thể dùng VContainer để inject Dependency một cách thuận tiện hơn ví dụ như trường hợp của class
UIMainManager đang được inject trong các IMenu

Lúc test game thì mình có phát hiện bug là khi đổi setting sang Board lớn hơn ví dụ 15x10 thì có một số
trường hợp sau khi ăn Item thì trong quá trình Fill Items ko rơi xuống hết và bị hổng 1 lỗ và mình cũng
chưa tìm ra nguyên nhân.