package Function;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class Timer {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Nhập thời gian bắt đầu (theo định dạng HH:mm:ss): ");
        String startTime = scanner.nextLine();
        System.out.println("Nhập thời gian kết thúc (theo định dạng HH:mm:ss): ");
        String endTime = scanner.nextLine();
        scanner.close();

        SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
        try {
            Date start = sdf.parse(startTime);
            Date end = sdf.parse(endTime);

            // Tính thời gian còn lại (đơn vị là mili giây)
            long remainingTime = end.getTime() - new Date().getTime();

            // Kiểm tra xem thời gian kết thúc có lớn hơn thời gian hiện tại không
            if (remainingTime > 0) {
                System.out.println("Thời gian bắt đầu: " + startTime);
                System.out.println("Thời gian kết thúc: " + endTime);
                System.out.println("Bắt đầu đếm ngược...");

                // Đếm ngược thời gian
                while (remainingTime > 0) {
                    // In thời gian còn lại
                    System.out.println("Thời gian còn lại: " + formatTime(remainingTime));
                    // Đợi 1 giây
                    Thread.sleep(1000);
                    // Giảm thời gian còn lại đi 1 giây (1000 mili giây)
                    remainingTime -= 1000;
                }

                System.out.println("Đã xong!");
            } else {
                System.out.println("Thời gian kết thúc phải sau thời gian hiện tại. Vui lòng nhập lại.");
            }
        } catch (Exception e) {
            System.out.println("Định dạng thời gian không hợp lệ. Vui lòng nhập lại.");
        }
    }

    // Hàm chuyển đổi thời gian từ mili giây sang giờ:phút:giây
    private static String formatTime(long timeInMillis) {
        long hours = timeInMillis / (60 * 60 * 1000);
        long minutes = (timeInMillis % (60 * 60 * 1000)) / (60 * 1000);
        long seconds = (timeInMillis % (60 * 1000)) / 1000;
        return String.format("%02d:%02d:%02d", hours, minutes, seconds);
    }
}
