package bigWebServiceSession2.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Books")
public class Book {
	@Id
	@Column(name = "BookId")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer bookId;
	@Column(name = "BookName")
	private String bookName;
	@Column(name = "Author")
	private String author;
	@Column(name = "Publisher")
	private String publisher;
	@Column(name = "Pages")
	private Integer pages;
	@Column(name = "Price")
	private Double price;
	
	
	public Book() {
		super();
		// TODO Auto-generated constructor stub
	}


	public Book(Integer bookId, String bookName, String author, String publisher, Integer pages, Double price) {
		super();
		this.bookId = bookId;
		this.bookName = bookName;
		this.author = author;
		this.publisher = publisher;
		this.pages = pages;
		this.price = price;
	}


	public Integer getBookId() {
		return bookId;
	}


	public void setBookId(Integer bookId) {
		this.bookId = bookId;
	}


	public String getBookName() {
		return bookName;
	}


	public void setBookName(String bookName) {
		this.bookName = bookName;
	}


	public String getAuthor() {
		return author;
	}


	public void setAuthor(String author) {
		this.author = author;
	}


	public String getPublisher() {
		return publisher;
	}


	public void setPublisher(String publisher) {
		this.publisher = publisher;
	}


	public Integer getPages() {
		return pages;
	}


	public void setPages(Integer pages) {
		this.pages = pages;
	}


	public Double getPrice() {
		return price;
	}


	public void setPrice(Double price) {
		this.price = price;
	}
	
}
