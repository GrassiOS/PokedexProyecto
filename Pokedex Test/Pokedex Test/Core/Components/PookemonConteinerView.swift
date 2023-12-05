//
//  PookemonConteinerView.swift
//  Pokedex Test
//
//  Created by Martin on 29/07/23.
//

import SwiftUI

struct PookemonConteinerView: View {
    let poke: Pokemon
    
    var body: some View {
        ZStack {
            RoundedRectangle(cornerRadius: 9)
                .frame(width: 279, height: 81)
                .foregroundColor(Color.fromString(poke.color) ?? .red)
                .shadow(color: .gray.opacity(0.2), radius: 5, x: 0, y: 0)
                .overlay {
                    Image(poke.type?.name ?? "fire")
                        .resizable()
                        .frame(width: 100, height: 100)
                        .alignmentGuide(HorizontalAlignment.center) { d in
                                            d[.trailing] - 160
                                }
                        .alignmentGuide(VerticalAlignment.center) { d in
                                            d[.top] + 50
                                }
                        .colorMultiply(Color.black.opacity(0.5))
                }
                .mask(RoundedRectangle(cornerRadius: 20))
            //Name and # and image
            HStack {
                VStack {
                    Text(poke.name.capitalized )
                        .font(.custom("GILROY-BOLD", size: 16))
                        .foregroundColor(textColorForBackground(pokeColor: poke.color))
                        .alignmentGuide(.lastTextBaseline) { d in
                        d[.bottom] - 10
                        }
                        .multilineTextAlignment(.leading)
                        .offset(x: -30, y: 0)
                    
                    Text(zeros(id: poke.id))
                        .font(.custom("GILROY-BLACK", size: 40))
                        .foregroundColor(.white.opacity(0.7))
                        .alignmentGuide(.lastTextBaseline) { d in
                            d[.bottom] - 10
                        }
                        .multilineTextAlignment(.leading)
                        .offset(x: -30, y: 0)
                    
                }
                
                AsyncImage(url: URL(string: poke.img ?? "")) { phase in
                    switch phase {
                    case .empty:
                        ProgressView()
                    case .success(let image):
                        image
                            .resizable()
                            .scaledToFill()
                            .frame(width: 90, height: 80)
                            .shadow(color: .gray.opacity(0.2), radius: 12)
                    case .failure:
                        Image("placeholder") // You can provide a placeholder image here
                            .resizable()
                            .scaledToFill()
                            .frame(width: 150, height: 150)
                    @unknown default:
                        EmptyView()
                    }
                }
            }
            
            
        }
        .frame(width: 279, height: 94)

    }
    
    func textColorForBackground(pokeColor: String) -> Color {
            if pokeColor ==  "red" || pokeColor ==  "purple" || pokeColor ==  "blue" || pokeColor ==  "pink"{
                return .white
            } else {
                return .black
            }
        }
}

struct PookemonConteinerView_Previews: PreviewProvider {
    static var previews: some View {
        PookemonConteinerView(poke: Pokemon.MOCK_POKEMON[0])
    }
}
