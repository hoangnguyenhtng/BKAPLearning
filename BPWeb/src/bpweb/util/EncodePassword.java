//package bpweb.util;
//
//import java.security.MessageDigest;
//
//public class EncodePassword {
//	public static String toSHA1(String str) {
//		String salt = "kladsjhgfalkdhfkdjasfghkajgfdyauwcva";
//		String result = null;
//		
//		str = str + salt;
//		try {
//			byte[] dataBytes = str.getBytes("UTF-8");
//			MessageDigest md = MessageDigest.getInstance("SHA-1");
//		}catch (Exception e) {
//			e.printStackTrace();
//		}
//		return result;
//	}
//	
//	public static void main(String args) {
//		System.out.println(toSHA1("123456"));
//	}
//}
